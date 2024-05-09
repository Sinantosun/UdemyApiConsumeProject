using FluentValidation.Results;
using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        void createMessage(string icon, string result)
        {
            TempData["Icon"] = icon;
            TempData["Result"] = result;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5269/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTestimonail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonail(TestimonialViewModel model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Testimonial", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                createMessage("success", "Referans kaydı eklendi.");
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateTestimonail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonail(TestimonialViewModel model)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/Testimonial", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                createMessage("success", "Referans Kaydı Güncellendi.");
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<ActionResult> DeleteTestimonail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5269/api/Testimonial?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var newurl = "wwwroot/" + jsondata;
                if (System.IO.File.Exists(newurl))
                {
                    System.IO.File.Delete(newurl);
                }
                createMessage("success", "Referans kaydı silindi.");

            }


            return RedirectToAction("Index");
        }
    }
}
