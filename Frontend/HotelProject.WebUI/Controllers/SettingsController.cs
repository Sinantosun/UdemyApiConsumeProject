using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> signInManager;

        public SettingsController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager)
        {
            _usermanager = usermanager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel userEditViewModel = new UserEditViewModel()
            {
                Email=user.Email,
                NameSurname = user.NameSurname,
                UserName=user.UserName
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            if (model.Password==model.ConfirmPassword)
            {
                var user = await _usermanager.FindByNameAsync(User.Identity.Name);

                user.NameSurname = model.NameSurname;
                user.Email = model.Email;
                user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, model.Password);
                await _usermanager.UpdateAsync(user);
                TempData["Result"] = "profiliniz güncellendi tekrar giriş yapmalısınız.";
                TempData["icon"] = "success";
                await signInManager.SignOutAsync();

                return RedirectToAction("Index","Login");
            }
           

            return View();
        }
    }
}
