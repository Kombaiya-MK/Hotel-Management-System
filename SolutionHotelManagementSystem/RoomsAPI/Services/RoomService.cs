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

        /// <summary>
        /// Method to get all rooms based on hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public ICollection<Room> GetRoomsUnderHotel(int hotelId)
        {
            var rooms =  _repo.GetAll().Where(x => x.HotelId == hotelId);
            return rooms.ToList();
        }

        /// <summary>
        /// Method to get available rooms based on hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public ICollection<Room> GetAvailableRooms(int hotelId)
        {
            var rooms = GetRoomsUnderHotel(hotelId).ToList();
            return rooms.Where(x => x.RoomStatus == true).ToList();
            
        }

        /// <summary>
        /// Method to get rooms based on amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public ICollection<Room> GetRoomsOnAmenties(string amenities)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomDescription.Contains(amenities)).ToList();

        }

        /// <summary>
        /// Method to get rooms based on price range
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public ICollection<Room> GetRoomsOnPrice(int max , int min)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomPrice <= max && x.RoomPrice >= min).ToList();

        }


        /// <summary>
        /// Method to add rooms 
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public Room AddRooms(Room room)
        {
            return _repo.Add(room);    
        }



        /// <summary>
        /// Method to remove rooms 
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public Room RemoveRooms(Room room)
        {
            return _repo.Delete(room.RoomID);
        }

        /// <summary>
        /// Method to update rooms 
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool UpdateRoom(Room room)
        {
            return _repo.Update(room);
        }


        //countability Functions

        /// <summary>
        /// Method to get number of rooms under hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int TotalNumberOfRoomsUnderHotel(int id)
        {
            return GetRoomsUnderHotel(id).Count;
        }

        /// <summary>
        /// Method to get number of rooms with given amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public int TotalNumberOfRoomsOnAmenities(string amenities)
        {
            return GetRoomsOnAmenties(amenities).Count;
        }

        /// <summary>
        /// Method to get number of rooms under given price range
        /// </summary>
        /// <param name="maxprice"></param>
        /// <param name="minprice"></param>
        /// <returns></returns>
        public int TotalNumberOfRoomsOnPrice(int maxprice , int minprice)
        {
            return GetRoomsOnPrice(maxprice,minprice).Count;
        }

    }
}
