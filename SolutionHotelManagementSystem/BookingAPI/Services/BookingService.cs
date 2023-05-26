using BookingAPI.Interfaces;
using BookingAPI.Models;

namespace BookingAPI.Services
{
    public class BookingService
    {
        private readonly IRepo<Booking, int> _repo;

        public BookingService(IRepo<Booking , int> repo)
        {
            _repo = repo;
        }

        public ICollection<Booking> GetBookingOnHotel(int id)
        {
            var bookings = _repo.GetAll();
            return bookings.Where(x => x.HotelID == id).ToList();
        }

        public ICollection<Booking> GetBookingOnUser(int id)
        {
            var bookings = _repo.GetAll();
            return bookings.Where(x => x.UserId == id).ToList();
        }

        public ICollection<Booking> GetAllBookings()
        {

            return _repo.GetAll();
        }

        public Booking GetBooking(int id)
        {
            return _repo.Get(id);
        }

        public bool Update(Booking booking)
        {
            return _repo.Update(booking);
        }

        public Booking Delete(Booking booking)
        {
            return _repo.Delete(booking.BookingId);
        }

        public bool AddBooking(Booking booking)
        {
            return _repo.Add(booking);
        }
    }
}
