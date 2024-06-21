using HotelProject.BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;
        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult GetStaffCount()
        {
            return Ok(_staffService.TGetStaffCount());
        }

        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            return Ok(_bookingService.TGetBookingCount());
        }

        [HttpGet("GetAppUserCount")]
        public IActionResult GetAppUserCount()
        {
            return Ok(_appUserService.TAppUserCount());
        }

        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            return Ok(_roomService.TGetRoomCount());
        }
    }
}
