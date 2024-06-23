using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5269/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string GuestName)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Booking/GetByGuestName/{GuestName}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                TempData["showAllButton"] = "true";
                return View(values);
            }
            return View();
        }




        public async Task<IActionResult> ApprovedReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Booking/UpdateBookingApproveById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Icon"] = "success";
                TempData["Result"] = "Rezervasyon Onaylandı";
              
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CancelReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Booking/UpdateBookingCancelByID?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Icon"] = "success";
                TempData["Result"] = "Rezervasyon İptal Edildi";

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> WaitReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Booking/UpdateBookingWaitByID?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Icon"] = "success";
                TempData["Result"] = "Rezervasyon Beklemeye Alındı";

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ReservationUpdate(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5269/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(result);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReservationUpdate(UpdateBookingDto model)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/Booking", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Icon"] = "success";
                TempData["Result"] = "Rezervasyon Güncellendi";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
