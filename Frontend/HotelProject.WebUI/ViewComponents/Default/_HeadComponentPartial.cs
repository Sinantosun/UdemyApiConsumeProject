using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _HeadComponentPartial  : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
