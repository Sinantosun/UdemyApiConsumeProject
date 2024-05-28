using AutoMapper;
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet("getLastRooms")]
        public IActionResult getLastRooms()
        {
            var values = _roomService.TgetLastThreeRooms();
            return Ok(values);
        }


        [HttpGet]
        public IActionResult Roomlist()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(CreateRoomDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedvalues = _mapper.Map<Room>(room);
            _roomService.TInsert(mappedvalues);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var value = _roomService.TGetById(id);
            _roomService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(room);
            _roomService.TUpdate(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var value = _roomService.TGetById(id);
            return Ok(value);
        }
    }
}
