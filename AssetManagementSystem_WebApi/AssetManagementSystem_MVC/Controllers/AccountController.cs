using AssetManagementSystem_MVC.Helper;
using AssetManagementSystem_WebApi;
using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private AssetDb _db;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> _signInManager, IConfiguration configuration, AssetDb _db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this.signInManager = _signInManager;
            this._db = _db;
        }

        BaseAddress _api = new BaseAddress();
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LoginMvc()
        {
            return View("LoginMvc");
        }
        public ActionResult ErrorR()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LoginMvc(Login model)
        {
            var User = await userManager.FindByNameAsync(model.Username);
            if (User != null && await userManager.CheckPasswordAsync(User, model.Password))
            {
                HttpClient client = _api.Initial();
                var res = await client.PostAsJsonAsync($"api/Authenticate/Login", model);
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Error");

                }
            }
            return RedirectToAction("Error");

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterMvc()
        {
            return View("RegisterMvc");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterMvc(Register model)
        {
       
            HttpClient client = _api.Initial();
            var res = await client.PostAsJsonAsync($"api/Authenticate/Register", model);
            Console.WriteLine(res);
            if (res.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ErrorR");
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
            return RedirectToAction("Error");
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
