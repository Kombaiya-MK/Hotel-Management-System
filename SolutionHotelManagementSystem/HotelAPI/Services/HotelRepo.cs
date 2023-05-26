using HotelAPI.Interfaces;
using HotelAPI.Models;
using System.Diagnostics;

namespace HotelAPI.Services
{
    /// <summary>
    /// Repository class that implemented functions which are implemented in the IRepo
    /// </summary>
    public class HotelRepo : IRepo<Hotel, int> // Implements the IRepo
    {
        private readonly HotelContext _hotels;

        /// <summary>
        /// Dependency Injection(Hotel Repo)
        /// </summary>
        /// <param name="context"></param>
        public HotelRepo(HotelContext context)
        {
            _hotels = context;
        }

        /// <summary>
        /// Method for Adding hotels info
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(Hotel item)
        {
            bool  status = false;
            try
            {
                _hotels.Hotels.Add(item);
                _hotels.SaveChanges();
                status = true;  
            }
            catch(NoValueException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return status;
        }

        /// <summary>
        /// Method for deleting the hotel info
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Hotel Delete(int key)
        {
            var hotel = Get(key);
            if(hotel != null)
            {
                _hotels.Hotels.Remove(hotel);
                _hotels.SaveChanges();
                return hotel;
            }
            return null;
        }
        /// <summary>
        ///Method for Get hotels details with id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Hotel Get(int key)
        {
            var hotel = _hotels.Hotels.FirstOrDefault(h => h.Hotel_Id == key);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
        }
        /// <summary>
        /// Method for getting all the available hotels info
        /// </summary>
        /// <returns></returns>
        public ICollection<Hotel> GetAll()
        {
            return _hotels.Hotels.ToList();
        }

        /// <summary>
        /// Method for updating hotel information
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Hotel item)
        {
            bool status = false;
            var hotel = Get(item.Hotel_Id);
            if (hotel != null)
            {
                hotel.Hotel_Name = item.Hotel_Name;
                hotel.Branch_id  = item.Branch_id;
                hotel.amenities = item.amenities;
                hotel.Starting_Price = item.Starting_Price;
                _hotels.SaveChanges();
                status = true;  
            }
            return status;
        }
    }
}
