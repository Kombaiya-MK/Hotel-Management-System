using HotelAPI.Models;
using HotelAPI.Models.DTO;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServices _service;

        public HotelController(HotelServices services) 
        {
            _service = services;    
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ICollection<HotelDTO>) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDTO>> GetAllHotels()
        {
            var hotels = _service.GetAllHotelsDetails();
            if(hotels.Count == 0)
            {
                return NotFound("No hotels available");
            }
            return Ok(hotels);
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDTO>> GetHotelsOnPrice(int max , int min )
        {
            var hotels = _service.GetHotelInPriceRange(max,min);
            if (max > 0 || min < 0)
                return BadRequest("Invalid Input");
            if (hotels.Count == 0)
            {
                return NotFound("No hotels available");
            }
            return Ok(hotels);
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDTO>> GetHotelsOnAmenities(string amenities)
        {
            var hotels = _service.GetHotelsOnAmenities(amenities);
            if (hotels.Count == 0)
            {
                return NotFound("No hotels available");
            }
            return Ok(hotels);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDTO>> GetHotel(int id)
        {

            if (id == 0)
                return BadRequest("Invalid Id");

            var hotel = _service.GetHotel(id);
            if (hotel == null)
            {
                return NotFound("No hotels available");
            }
            return Ok(hotel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> AddHotel([FromBody] Hotel hotel)
        {
            bool status = _service.AddHotel(hotel);
            if (status)
            {
                return Ok(hotel);
            }
            return BadRequest("Duplicate data are not allowed");
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> RemoveHotel([FromBody] Hotel hotel)
        {
            bool status = _service.RemoveHotel(hotel.Hotel_Id) != null;
            if (status)
            {
                return Ok(hotel);
            }
            return BadRequest("No data available to delete");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> UpdateHotel([FromBody] Hotel hotel)
        {
            bool status = _service.UpdateHotels(hotel);
            if (status)
            {
                return Ok(hotel);
            }
            return BadRequest("data updation failed");
        }
    }
}
