using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Booking
{
    public class _BookingCoverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
