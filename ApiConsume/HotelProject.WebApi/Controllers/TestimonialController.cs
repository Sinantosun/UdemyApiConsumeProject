using FluentValidation.Results;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.BusinnessLayer.ValidationRules.TestimonialRules;
using HotelProject.DtoLayer.ApiResultDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                TestimonialValidator validationRules = new TestimonialValidator();
                ValidationResult validationResult = validationRules.Validate(testimonial);
                if (validationResult.IsValid)
                {
                    _testimonialService.TInsert(testimonial);
                    return Ok();
                }
                else
                {
                    List<ResultApiDto> list = new List<ResultApiDto>();
                    foreach (var item in validationResult.Errors)
                    {
                        list.Add(new ResultApiDto
                        {
                            errorMessage = item.ErrorMessage,
                            propertyName = item.PropertyName,

                        });

                    }
                    return BadRequest(list);
                }
           
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
            TestimonialValidator validationRules = new TestimonialValidator();
            ValidationResult validationResult = validationRules.Validate(testimonial);
            if (validationResult.IsValid)
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
            else
            {
                List<ResultApiDto> list = new List<ResultApiDto>();
                foreach (var item in validationResult.Errors)
                {
                    list.Add(new ResultApiDto
                    {
                        errorMessage = item.ErrorMessage,
                        propertyName = item.PropertyName,

                    });

                }
                return BadRequest(list);
            }



        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
