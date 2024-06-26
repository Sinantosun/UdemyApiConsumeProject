﻿using HotelProject.BusinnessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService bookingService)
        {
            _BookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Bookinglist()
        {
            var values = _BookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _BookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            _BookingService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _BookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("UpdateBookingApproveById")]
        public IActionResult UpdateBookingApproveById(int id)
        {
            _BookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }

        [HttpGet("UpdateBookingCancelByID")]
        public IActionResult UpdateBookingCancelByID(int id)
        {
            _BookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }

        [HttpGet("UpdateBookingWaitByID")]
        public IActionResult UpdateBookingWaitByID(int id)
        {
            _BookingService.TBookingStatusChangeWait(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var value = _BookingService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetLastSixBookingList")]
        public IActionResult GetLastSixBookingList()
        {
            var value = _BookingService.TGetLastSixBookingList();
            return Ok(value);
        }

        [HttpGet("GetByGuestName/{guestName}")]
        public IActionResult GetByGuestName(string guestName)
        {
            var value = _BookingService.TGetBookingByGuestName(guestName);
            return Ok(value);
        }
    }
}
