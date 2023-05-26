using BookingAPI.Models;
using BookingAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _service;

        public BookingController(BookingService services)
        {
            _service = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetAllBooking()
        {
            var Bookings = _service.GetAllBookings();
            if (Bookings.Count == 0)
            {
                return NotFound("No Bookings available");
            }
            return Ok(Bookings);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetBookingsOnUser(int id)
        {
            var Bookings = _service.GetBookingOnUser(id);
            if (Bookings.Count == 0)
            {
                return NotFound("No Bookings available");
            }
            return Ok(Bookings);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetBookingsOnHotels(int id)
        {
            var Bookings = _service.GetBookingOnUser(id);
            if (Bookings.Count == 0)
            {
                return NotFound("No Bookings available");
            }
            return Ok(Bookings);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Booking>> GetBooking(int id)
        {
            var booking = _service.GetBooking(id);
            if (booking == null)
            {
                return NotFound("No Bookings available");
            }
            return Ok(booking);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> AddBooking([FromBody] Booking Booking)
        {
            bool status = _service.AddBooking(Booking);
            if (status)
            {
                return Ok(Booking);
            }
            return BadRequest("Duplicate data are not allowed");
        }
    }
}
