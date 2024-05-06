using HotelProject.HotelProject.WebUI.ImageValidations;
using HotelProject.WebUI.ImageCrud;
using HotelProject.WebUI.Models.ApiResult;
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
        public async Task<IActionResult> AddTestimonail(CreateTestimonialViewModel model)
        {
            ModelState.Clear();
            if (model.FromFileImage != null)
            {
                var ex = Path.GetExtension(model.FromFileImage.FileName);
                bool imageExtentionValidator = ImageValidator.CheckImageExtention(ex);
                if (imageExtentionValidator)
                {
                    var newImageName = Guid.NewGuid() + ex;
                    model.Image = "/Images/Testimonail/" + newImageName;

                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(model);
                    StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("http://localhost:5269/api/Testimonial", strContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Testimonail/", newImageName);
                        CreateImage.Create(model.FromFileImage, location);

                        createMessage("success", "Referans kaydı eklendi.");
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
                }
                else
                {
                    ModelState.AddModelError("FromFileImage", "Seçilen dosya türü desteklenmiyor.");
                }

            }
            else
            {
                ModelState.AddModelError("FromFileImage", "Lütfen Resim Seçin");
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
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonail(UpdateTestimonialViewModel model)
        {
            ModelState.Clear();

            if (model.formFile != null)
            {
                var ex = Path.GetExtension(model.formFile.FileName);
                bool imageExtentionValidator = ImageValidator.CheckImageExtention(ex);
                if (imageExtentionValidator)
                {
                    var newImageName = Guid.NewGuid() + ex;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Testimonail/", newImageName);
                    CreateImage.Create(model.formFile, location);
                    model.Image = "/Images/Testimonail/" + newImageName;
                }
                else
                {
                    createMessage("error", "Dosya biçimi desteklenmiyor, işleminize devam edemiyoruz lütfen seçilen dosyayı kontrol edin.");
                    return RedirectToAction("Index");
                }
            
             
            }


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5269/api/Testimonial", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                createMessage("success", "Referans Kaydı Güncellendi.");
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
