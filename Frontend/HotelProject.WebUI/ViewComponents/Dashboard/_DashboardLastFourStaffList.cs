using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastFourStaffList : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public _DashboardLastFourStaffList(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientfactory.CreateClient();
            var responesMessage = await client.GetAsync("http://localhost:5269/api/Staff/GetLastFourStaffList");
            if (responesMessage.IsSuccessStatusCode)
            {
                var jsonData = await responesMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(result);
            }
            return View();
        }
    }
}
