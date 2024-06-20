using AutoMapper;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;
        private readonly IMapper _mapper;


        public WorkLocationController(IWorkLocationService workLocationService, IMapper mapper)
        {
            _workLocationService = workLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult WorkLocationlist()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddWorkLocation(CreateWorkLocationDto workLocation)
        {
            var value = _mapper.Map<WorkLocation>(workLocation);
            _workLocationService.TInsert(value);
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteWorkLocation(int id)
        {
            var value = _workLocationService.TGetById(id);
            _workLocationService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(UpdateWorkLocationDto workLocation)
        {
            var value = _mapper.Map<WorkLocation>(workLocation);
            _workLocationService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocationById(int id)
        {
            var value = _workLocationService.TGetById(id);
            return Ok(value);
        }
    }
}
