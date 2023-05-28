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

        /// <summary>
        /// Method for getting all the available bookings based on hotels 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Booking> GetBookingOnHotel(int id)
        {
            var bookings = _repo.GetAll();
            return bookings.Where(x => x.HotelID == id).ToList();
        }

        /// <summary>
        /// Method to get bookings based on the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Booking> GetBookingOnUser(int id)
        {
            var bookings = _repo.GetAll();
            return bookings.Where(x => x.UserId == id).ToList();
        }

        /// <summary>
        /// Method to get all bookings
        /// </summary>
        /// <returns></returns>
        public ICollection<Booking> GetAllBookings()
        {

            return _repo.GetAll();
        }

        /// <summary>
        /// Method to get bookings based on booking id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking GetBooking(int id)
        {
            return _repo.Get(id);
        }

        /// <summary>
        /// Method to update bookings
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool Update(Booking booking)
        {
            return _repo.Update(booking);
        }

        /// <summary>
        /// Method to delete bookings 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public Booking Delete(Booking booking)
        {
            return _repo.Delete(booking.BookingId);
        }

        /// <summary>
        /// Method to delete bookings
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool AddBooking(Booking booking)
        {
            return _repo.Add(booking);
        }


        //Countability Functions

        /// <summary>
        /// Method to gettotal number of  bookings 
        /// </summary>
        /// <returns></returns>
        public int TotalOfBookings()
        {
            return _repo.GetAll().Count;
        }

        /// <summary>
        /// Method to gettotal number of  bookings based on hotels
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int TotalOfBookingsBasedOnHotels(int id)
        {
            return GetBookingOnHotel(id).Count;
        }
        /// <summary>
        /// Method to gettotal number of  bookings based on user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int TotalOfBookingsBasedOnUser(int id)
        {
            return GetBookingOnUser(id).Count;
        }
    }
}
