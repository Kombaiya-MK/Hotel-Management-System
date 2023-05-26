using BookingAPI.Interfaces;
using BookingAPI.Models;
using System.Diagnostics;

namespace BookingAPI.Services
{
    public class BookingRepo : IRepo<Booking, int>
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }
        public bool Add(Booking item)
        {
            bool status = false;
            try
            {
                _context.Bookings.Add(item);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        public Booking Delete(int key)
        {
            var booking = Get(key);
            if(booking != null)
            {
                _context.Remove(booking);
                _context.SaveChanges();
                return booking;
            }
            return null;
        }

        public Booking Get(int key)
        {
            var booking = _context.Bookings.FirstOrDefault(h => h.BookingId == key);
            if (booking == null)
            {
                return null;
            }
            return booking;
        }

        public ICollection<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public bool Update(Booking item)
        {
            bool status = false;
            var booking = Get(item.BookingId);
            if(booking != null)
            {
                booking.HotelID = item.HotelID;
                booking.NumOfDays = item.NumOfDays;
                booking.RoomId = item.RoomId;
                booking.TotalAmount = item.TotalAmount;
                booking.UserId = item.UserId;
                _context.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}
