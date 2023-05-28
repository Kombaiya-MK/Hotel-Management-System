using Microsoft.EntityFrameworkCore;
using RoomsAPI.Interfaces;
using RoomsAPI.Models;
using System.Diagnostics;

namespace RoomsAPI.Services
{
    public class RoomRepo : IRepo<Room, int>
    {
        private readonly RoomContext _rooms;

        public RoomRepo(RoomContext context)
        {
            _rooms = context;
        }
        public Room Add(Room item)
        {
            try
            {
                _rooms.Rooms.Add(item);
                _rooms.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return item;
        }

        public Room Delete(int key)
        {
            var room = Get(key);
            try
            {
                _rooms.Rooms.Remove(room);
                _rooms.SaveChanges();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return room;
        }

        public Room Get(int key)
        {
            var room = _rooms.Rooms.FirstOrDefault(r => r.RoomID == key);
            if (room == null)
                return null;
            return room;
        }

        public ICollection<Room> GetAll()
        {
            return _rooms.Rooms.ToList();  
        }

        public bool Update(Room item)
        {
            bool status = false;
            var room = Get(item.RoomID);
            if(room != null) 
            {
                room.RoomDescription = item.RoomDescription;    
                room.RoomType = item.RoomType;  
                room.RoomStatus = item.RoomStatus;
                room.HotelId = item.HotelId;
                room.RoomPrice = item.RoomPrice;
                _rooms.SaveChanges(); 
                status = true;
            }
            return status;
        }
    }
}
