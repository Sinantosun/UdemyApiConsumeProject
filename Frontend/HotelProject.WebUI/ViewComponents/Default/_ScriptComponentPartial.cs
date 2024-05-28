using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ScriptComponentPartial : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
