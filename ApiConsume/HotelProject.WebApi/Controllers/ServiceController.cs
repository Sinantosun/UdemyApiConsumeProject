using HotelProject.BusinnessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ISubscribeService _serviceService;

        public ServiceController(ISubscribeService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Servicelist()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(Subscribe service)
        {
            _serviceService.TInsert(service);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.TGetById(id);
            _serviceService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Subscribe service)
        {
            _serviceService.TUpdate(service);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
    }
}
