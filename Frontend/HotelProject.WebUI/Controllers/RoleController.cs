using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var value = _roleManager.Roles.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            var result = await _roleManager.CreateAsync(new AppRole
            {
                Name = model.RoleName
            });
            if (result.Succeeded)
            {
                TempData["Result"] = "Kayıt Eklendi";
                TempData["icon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {

            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            TempData["Result"] = "Kayıt Silindi";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {

            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {

            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);
            value.Name = model.RoleName;
            await _roleManager.UpdateAsync(value);
            TempData["Result"] = "Kayıt Güncellendi";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }
    }
}
