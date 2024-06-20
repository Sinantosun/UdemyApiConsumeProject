using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ConatctDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            //http://localhost:5269/api/MessageCategory

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5269/api/MessageCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

                List<SelectListItem> values = (from x in result
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.MessageCategoryID.ToString(),
                                               }).ToList();

                ViewBag.CategoryList = values;
            }


            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Contact", str);
            return RedirectToAction("Index", "Default");
        }
    }
}
