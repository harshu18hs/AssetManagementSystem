using AssetManagementSystem_MVC.Helper;
using AssetManagementSystem_MVC;
using AssetManagementSystem_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System.Net.Http.Json;
using AssetManagementSystem_WebApi.Models;

namespace AssetManagementSystem_MVC.Controllers
{
    public class BooksController : Controller
    {
        AssetDb _context = new AssetDb();
        BaseAddress _api = new BaseAddress();

        public ActionResult ERRORPAGE1()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Books");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(results);
            }
            return View(books);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var book = new Book();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Books/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(results);
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult AddOrEdit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Book book)
        {
            List<Book> books = new List<Book>();
            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<Book>($"api/Books/PostBooks", book);
            if (postTask.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View("ERRORPAGE1");

        }

        [HttpGet]
        public List<Book> Get()
        {
            return _context.Books.ToList();
        }
        [HttpGet("Id")]
        public Book GetBook(int Id)
        {
            var book = _context.Books.Where(a => a.Id == Id).SingleOrDefault();
            return book;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}