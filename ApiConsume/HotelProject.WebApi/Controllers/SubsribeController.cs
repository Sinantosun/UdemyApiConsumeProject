using HotelProject.BusinnessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsribeController : ControllerBase
    {
        private readonly ISubscribeService _subsribeService;

        public SubsribeController(ISubscribeService subsribeService)
        {
            _subsribeService = subsribeService;
        }

        [HttpGet]
        public IActionResult Subsribelist()
        {
            var values = _subsribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubsribe(Subscribe subsribe)
        {
            _subsribeService.TInsert(subsribe);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubsribe(int id)
        {
            var value = _subsribeService.TGetById(id);
            _subsribeService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubsribe(Subscribe subsribe)
        {
            _subsribeService.TUpdate(subsribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubsribeById(int id)
        {
            var value = _subsribeService.TGetById(id);
            return Ok(value);
        }
    }
}
