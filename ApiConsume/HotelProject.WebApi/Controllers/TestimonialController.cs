using HotelProject.BusinnessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonailService _testimonialService;

        public TestimonialController(ITestimonailService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult Testimoniallist()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
                    _testimonialService.TInsert(testimonial);
                    return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok(value.Image);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
                var values = _testimonialService.TGetById(testimonial.TestimonialID);
                values.Name = testimonial.Name;
                values.Title = testimonial.Title;
                values.Description = testimonial.Description;
                if (testimonial.Image!=null)
                {
                    values.Image = testimonial.Image;
                
                }
                _testimonialService.TUpdate(values);
                return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
