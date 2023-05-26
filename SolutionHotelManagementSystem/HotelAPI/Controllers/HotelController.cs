using HotelAPI.Models.DTO;
using HotelAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServices _service;

        public HotelController(HotelServices services) 
        {
            _service = services;    
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDTO>> Get()
        {
            var hotels = _service.GetAllHotelsDetails();
            if(hotels.Count == 0)
            {
                return NotFound("No hotels available");
            }
            return Ok(hotels);
        }

    }
}
