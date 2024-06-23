using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.DAL;
using HotelProject.WebUI.Dtos.Subsribe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]

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
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            createBookingDto.Description = "Değerlendirilmede";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5269/api/Booking", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                MailManager.SendMail("Rezervasyonunuz Alnıdı", createBookingDto.Mail, "Sayın, " + createBookingDto.NameSurname.ToUpper() + $"<br><br> Hoteiler otel rezervasyon randevünüz başarıyla alındı rezervasyon durumunuza telefon numaranız veya mail adresiniz üzerinden geri dönüş sağlanacaktır. <br><br>  Rezervasyon bilgileriniz aşağıdaki gibidir. <br><br> <table border=1 cellpadding=10 cellspacing=0 style=border-collapse: collapse; width: 100%; max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif;><thead><tr><th>Ad Soyad</th><th>Giriş Tarihi</th><th>Çıkış Tarihi</th></tr></thead><tbody><tr><td>{createBookingDto.NameSurname}</td><td>{(((DateTime)createBookingDto.CheckIn).ToString("f"))}</td> <td>{(((DateTime)createBookingDto.CheckOut).ToString("f"))}</td></tr></tbody></table> <br><br> Mutlu Günler! <br> Hotiler Rezervasyon");
            }
            return RedirectToAction("Index", "Default");
        }
    }
}
