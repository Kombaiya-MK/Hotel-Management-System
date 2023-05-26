namespace RoomsAPI.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public bool RoomStatus { get; set; }
        public string RoomDescription { get; set; } 
        public double RoomPrice { get; set; }
        public int HotelId { get; set; }   
        
    }
}
