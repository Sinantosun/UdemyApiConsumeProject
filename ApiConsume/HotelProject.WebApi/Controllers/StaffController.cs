using FluentValidation.Results;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.BusinnessLayer.ValidationRules.StaffRules;
using HotelProject.DtoLayer.ApiResultDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult Stafflist()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            StaffValidator validationRules = new StaffValidator();
            ValidationResult validationResult = validationRules.Validate(staff);
            if (validationResult.IsValid)
            {
                _staffService.TInsert(staff);
                return Ok();
            }
            else
            {
                List<ResultApiDto> results = new List<ResultApiDto>();
                foreach (var item in validationResult.Errors)
                {
                    results.Add(new ResultApiDto()
                    {
                        errorMessage=item.ErrorMessage,
                        propertyName=item.PropertyName,
                    });
                }
                return BadRequest(results);

            }


        }
        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
           var value = _staffService.TGetById(id);
            _staffService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var value = _staffService.TGetById(id);
            return Ok(value);
        }
    }
}
