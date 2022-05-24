using AssetManagementSystem_MVC.Helper;
using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem_MVC.Controllers
{
    public class AuthenticateController : Controller
    {
        
        BaseAddress _api = new BaseAddress();
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LoginMvc()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> LoginMvc(Login model)
        {
            HttpClient client = _api.Initial();
            var res = await client.PostAsJsonAsync($"api/Authenticate/Login", model);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("UnauthorizeError");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterMvc()
        {
            return View("Register");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterMvc(Register model)
        {
            HttpClient client = _api.Initial();
            var res = await client.PostAsJsonAsync($"api/Authenticate/Register", model);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("UnauthorizeError");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RequestAssetMVC(RequestAsset model)
        {
            HttpClient client = _api.Initial();
            var res = await client.PostAsJsonAsync($"api/Authenticate/RequestAsset", model);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("UnauthorizeError");
        }

    }
}
