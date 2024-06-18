using HotelProject.WebUI.Dtos.Subsribe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SubscribeEmail(string Mail)
        {
            ResultSubcirbeDto resultSubcirbeDto = new ResultSubcirbeDto()
            {
                Mail = Mail,
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultSubcirbeDto);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Subsribe", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json("success");
            }
            else
            {
                return Json(null);
            }

        }
    }
}
