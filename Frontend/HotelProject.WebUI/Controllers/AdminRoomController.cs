using HotelProject.WebUI.Dtos.RoomDto;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
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
            var responseMessage = await client.GetAsync("http://localhost:5269/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto model)
        {
            ModelState.Clear();
            if (model.Star % 1 == 0 && model.Star <= 5)
            {

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5269/api/Room", strContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    createMessage("success", "Oda kaydı eklendi.");
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ModelState.AddModelError("Star", "lütfen bu alana 0-5 arasında pozitif tam sayı değeri giriniz.");
            }
            return View();
        }

        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto model)
        {
            ModelState.Clear();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/Room", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                createMessage("success", "Oda Kaydı Güncellendi.");
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<ActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5269/api/Room?id={id}");
            createMessage("success", "Oda kaydı silindi.");
            return RedirectToAction("Index");
        }
    }
}
