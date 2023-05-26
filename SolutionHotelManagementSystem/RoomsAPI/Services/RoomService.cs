using RoomsAPI.Interfaces;
using RoomsAPI.Models;

namespace RoomsAPI.Services
{
    public class RoomService
    {
        private readonly IRepo<Room, int> _repo;

        public RoomService(IRepo<Room , int> repo) {
            _repo = repo;
        }

        public ICollection<Room> GetRoomsUnderHotel(int hotelId)
        {
            var rooms =  _repo.GetAll().Where(x => x.HotelId == hotelId);
            return rooms.ToList();
        }

        public ICollection<Room> GetAvailableRooms(int hotelId)
        {
            var rooms = GetRoomsUnderHotel(hotelId).ToList();
            return rooms.Where(x => x.RoomStatus == true).ToList();
            
        }

        public ICollection<Room> GetRoomsOnAmenties(string amenities)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomDescription.Contains(amenities)).ToList();

        }
        public ICollection<Room> GetRoomsOnPrice(int max , int min)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomPrice <= max && x.RoomPrice >= min).ToList();

        }

        public Room AddRooms(Room room)
        {
            return _repo.Add(room);    
        }


        public Room RemoveRooms(Room room)
        {
            return _repo.Delete(room.RoomID);
        }

        public bool UpdateRoom(Room room)
        {
            return _repo.Update(room);
        }
    }
}
