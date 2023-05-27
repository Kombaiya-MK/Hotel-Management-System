namespace BookingAPI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int HotelID { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int NumOfDays { get; set; }
        public double? TotalAmount { get; set; }

    }
}
