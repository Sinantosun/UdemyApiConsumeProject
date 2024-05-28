using HotelProject.BusinnessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpGet]
        public IActionResult Aboutlist()
        {
            var values = _aboutUsService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAbout(AboutUs aboutUs)
        {
            _aboutUsService.TInsert(aboutUs);
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutUsService.TGetById(id);
            _aboutUsService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(AboutUs aboutUs)
        {
            _aboutUsService.TUpdate(aboutUs);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var value = _aboutUsService.TGetById(id);
            return Ok(value);
        }
    }
}

