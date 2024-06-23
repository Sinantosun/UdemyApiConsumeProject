using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5269/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto model)
        {
            ModelState.Clear();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/About", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Result"] = "Hakkımızda bilgisi eklendi";
                TempData["icon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            ModelState.Clear();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/About", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Result"] = "Hakkımızda bilgisi güncellendi";
                TempData["icon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            //http://localhost:5269/api/About

            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5269/api/About?id={id}");
            TempData["Result"] = "Hakkımızda bilgisi silindi";
            TempData["icon"] = "success";
            return RedirectToAction("Index");
        }

    }
}
