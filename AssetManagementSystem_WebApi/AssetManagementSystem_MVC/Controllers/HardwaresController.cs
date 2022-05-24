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
    public class HardwaresController : Controller
    {
        AssetDb _context = new AssetDb();
        BaseAddress _api = new BaseAddress();
        public ActionResult ERRORPAGE2()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            List<Hardware> hardwares = new List<Hardware>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Hardwares");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                hardwares = JsonConvert.DeserializeObject<List<Hardware>>(results);
            }
            return View(hardwares);
        }
        public async Task<IActionResult> Details(int Model_No)
        {
            var hardware = new Hardware();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Hardwares/{Model_No}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                hardware = JsonConvert.DeserializeObject<Hardware>(results);
            }
            return View(hardware);
        }
       
        [HttpGet]
        public ActionResult AddOrEdit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Hardware hardware)
        {
            List<Hardware> hardwares = new List<Hardware>();
            HttpClient client = _api.Initial();
            var postTask = await client.PostAsJsonAsync<Hardware>($"api/Hardwares/PostHardwares", hardware);
            if (postTask.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index");
            }

            return View("ERRORPAGE2");

        }

        [HttpGet]
        public List<Hardware> Get()
        {
            return _context.Hardwares.ToList();
        }
        [HttpGet("Model_No")]
        public Hardware GetHardware(int Model_No)
        {
            var hardware = _context.Hardwares.Where(a => a.Model_No == Model_No).SingleOrDefault();
            return hardware;
        }
        
        [HttpDelete("{Model_No}")]
        public async Task<IActionResult> Delete(int Model_No)
        {
            var hardware = await _context.Hardwares.FindAsync(Model_No);
            if (hardware == null)
            {
                return NotFound();
            }
            _context.Hardwares.Remove(hardware);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}