using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        TempData["Result"] = "Giriş Başarılı, Hoşgeldiniz";
                        TempData["Icon"] = "success";
                        return RedirectToAction("Index", "Staff");
                    }
                    else
                    {
                        TempData["Result"] = "Giriş Başarılı, Hoşgeldiniz";
                        TempData["Icon"] = "success";
                        return Redirect(ReturnUrl);
                    }
                }
                else
                {
                    TempData["userResult"] = "kullanıcı adı veya şifre hatalı";
                }
            }

            return View();

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
