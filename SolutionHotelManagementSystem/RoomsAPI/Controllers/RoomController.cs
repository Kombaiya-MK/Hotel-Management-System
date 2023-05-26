using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsAPI.Models;
using RoomsAPI.Services;

namespace RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Room>> GetAvailableRooms(int id)
        {
            var rooms = _service.GetAvailableRooms(id);
            if (rooms.Count == 0)
            {
                return NotFound("No Rooms available");
            }
            return Ok(rooms);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Room>> GetallRooms(int id)
        {
            var rooms = _service.GetRoomsUnderHotel(id);
            if (rooms.Count == 0)
            {
                return NotFound("No rooms available");
            }
            return Ok(rooms);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Room>> GetHotelsOnAmenities(string amenities)
        {
            var rooms = _service.GetRoomsOnAmenties(amenities);
            if (rooms.Count == 0)
            {
                return NotFound("No rooms available");
            }
            return Ok(rooms);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> AddRooms([FromBody] Room room)
        {
            bool status = _service.AddRooms(room) != null;
            if (status)
            {
                return Ok(room);
            }
            return BadRequest("Duplicate data are not allowed");
        }

        [HttpPut]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> UpdateRooms([FromBody] Room room)
        {
            bool status = _service.UpdateRoom(room);
            if (status)
            {
                return Ok(room);
            }
            return BadRequest("Updation Filed");
        }


        [HttpDelete]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> DeleteRooms([FromBody] Room room)
        {
            bool status = _service.RemoveRooms(room) != null;
            if (status)
            {
                return Ok(room);
            }
            return BadRequest("Deletion Filed");
        }


        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Room>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Room>> GetHotelsOnPrice(int max, int min)
        {
            var rooms = _service.GetRoomsOnPrice(max, min);
            if (rooms.Count == 0)
            {
                return NotFound("No rooms available");
            }
            return Ok(rooms);
        }
    }
}
