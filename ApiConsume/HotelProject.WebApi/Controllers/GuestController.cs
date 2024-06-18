using AutoMapper;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;
        private readonly IMapper _mapper;

        public GuestController(IGuestService GuestService, IMapper mapper)
        {
            _GuestService = GuestService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Guestlist()
        {
            var values = _GuestService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest(CreateGuestDto guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedvalues = _mapper.Map<Guest>(guest);
            _GuestService.TInsert(mappedvalues);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            var value = _GuestService.TGetById(id);
            _GuestService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(UpdateGuestDto guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Guest>(guest);
            _GuestService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuestById(int id)
        {
            var value = _GuestService.TGetById(id);
            return Ok(value);
        }
    }
}
