using HotelProject.WebUI.Models.ApiResult;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
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
            var responseMessage = await client.GetAsync("http://localhost:5269/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(CreateStaffViewModel model)
        {
            ModelState.Clear();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Staff", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                createMessage("success", "Personel kaydı eklendi.");
                return RedirectToAction("Index");
            }
            else
            {
                var resultJson = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultApiViewModel>>(resultJson);
                foreach (var item in result)
                {
                    ModelState.AddModelError(item.propertyName, item.errorMessage);
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            ModelState.Clear();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/Staff", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                createMessage("success", "Personel Kaydı Güncellendi.");
                return RedirectToAction("Index");
            }
            else
            {
                var resultJson = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultApiViewModel>>(resultJson);
                foreach (var item in result)
                {
                    ModelState.AddModelError(item.propertyName, item.errorMessage);
                }
            }
            return View();
        }


        public async Task<ActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5269/api/Staff?id={id}");
            createMessage("success", "Personel kaydı silindi.");
            return RedirectToAction("Index");
        }
    }
}
