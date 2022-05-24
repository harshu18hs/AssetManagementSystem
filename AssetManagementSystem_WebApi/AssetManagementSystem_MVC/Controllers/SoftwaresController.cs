using AssetManagementSystem_MVC.Helper;
using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AssetManagementSystem_MVC.Controllers
{
    public class SoftwaresController : Controller
    {
        AssetDb _context = new AssetDb();
        BaseAddress _api = new BaseAddress();
        public ActionResult ERRORPAGE3()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Software> software = new List<Software>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Softwares");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                software = JsonConvert.DeserializeObject<List<Software>>(results);
            }
            return View(software);
        }
        public async Task<IActionResult> Details(int Software_Id)
        {
            var software = new Software();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Softwares/{Software_Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                software = JsonConvert.DeserializeObject<Software>(results);
            }
            return View(software);
        }
        public ActionResult AddOrEdit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Software software)
        {
            List<Software> softwares = new List<Software>();
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<Software>($"api/Softwares/PostSoftwares", software);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return View(softwares);
            }
            return View("ERRORPAGE3");
           

        }
        [HttpGet]
        public List<Software> Get()
        {
            return _context.Softwares.ToList();
        }
        [HttpGet("Software_Id")]
        public Software GetSoftware(int Software_Id)
        {
            var software = _context.Softwares.Where(a => a.Software_Id == Software_Id).SingleOrDefault();
            return software;
        }

        [HttpDelete("{Software_Id}")]
        public async Task<IActionResult> Delete(int Software_Id)
        {
            var software = await _context.Softwares.FindAsync(Software_Id);
            if (software == null)
            {
                return NotFound();
            }
            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
