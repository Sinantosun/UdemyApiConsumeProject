using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult AddGuest()
        {
            return View();
        }
    }
}
