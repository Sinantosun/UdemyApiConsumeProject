using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.Subsribe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{

    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<PartialViewResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            createBookingDto.Description = "Değerlendirilmede";    
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Booking", str);
            return PartialView();
        }
    }
}
