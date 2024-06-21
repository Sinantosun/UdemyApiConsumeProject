using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var StaffCountResponseMessage = await client.GetAsync("http://localhost:5269/api/DashboardWidget");
            var StaffCountJsonData = await StaffCountResponseMessage.Content.ReadAsStringAsync();
            ViewBag.GetStaffCount = StaffCountJsonData;

            var BookingCountResponseMessage = await client.GetAsync("http://localhost:5269/api/DashboardWidget/GetBookingCount");
            var BookingCountJsonData = await BookingCountResponseMessage.Content.ReadAsStringAsync();
            ViewBag.GetBookingCount = BookingCountJsonData;

            var AppUserCountResponseMessage = await client.GetAsync("http://localhost:5269/api/DashboardWidget/GetAppUserCount");
            var AppUserCountJsonData = await AppUserCountResponseMessage.Content.ReadAsStringAsync();
            ViewBag.GetAppUserCount = AppUserCountJsonData;

            var RoomCountResponseMessage = await client.GetAsync("http://localhost:5269/api/DashboardWidget/GetRoomCount");
            var RoomCountJsonData = await RoomCountResponseMessage.Content.ReadAsStringAsync();
            ViewBag.GetRoomCount = RoomCountJsonData;


            return View();
        }
    }
}
