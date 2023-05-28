using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;

namespace HotelAPI.Services
{
    public class HotelServices
    {
        private readonly IRepo<Hotel, int> _hotelRepo;
        private readonly IRepo<Branch, int> _branchRepo;



        /// <summary>
        /// Dependency Injection => Hotel Service
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="branch"></param>
        public HotelServices(IRepo<Hotel,int> hotel , IRepo<Branch , int> branch)
        {
            _hotelRepo = hotel;
            _branchRepo = branch;
        }


        /// <summary>
        /// Method to display the hotel details to the user
        /// </summary>
        /// <returns></returns>
        /// 
        public ICollection<HotelDTO> GetAllHotelsDetails()
        {
            var hotels = _hotelRepo.GetAll();
            var branches = _branchRepo.GetAll();
            return MapDTO(hotels, branches);
        }

        /// <summary>
        /// Method for creating Data Transfer Object for frontend
        /// </summary>
        /// <param name="hotels"></param>
        /// <param name="branches"></param>
        /// <returns></returns>
        public ICollection<HotelDTO> MapDTO(ICollection<Hotel> hotels , ICollection<Branch> branches)
        {
            IList<HotelDTO> Hotels = new List<HotelDTO>();
            foreach (var obj in hotels)
            {
                HotelDTO hotel = new HotelDTO();
                hotel.Hotel_id = obj.Hotel_Id;
                hotel.Hotel_name = obj.Hotel_Name;
                Hotels.Add(hotel);
            }
            foreach (var obj in branches)
            {
                HotelDTO hotel = new HotelDTO();
                hotel.Hotel_phone = obj.Branch_Phone;
                hotel.Hotel_address = obj.Branch_Location;
                Hotels.Add(hotel);
            }
            return Hotels;
        }

        /// <summary>
        /// Method for adding hotel to the database
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public bool AddHotel(Hotel hotel)
        {
            var branch = _branchRepo.Get(hotel.Branch_id);
            if (branch != null)
                return _hotelRepo.Add(hotel);
            return false;
        }

        /// <summary>
        /// Method For add branch informations
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public bool AddBranch(Branch branch)
        {
            return _branchRepo.Add(branch); 
        }

        /// <summary>
        /// Method for removing branches
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Branch RemoveBranch(int id)
        {
            return _branchRepo.Delete(id);
        }

        /// <summary>
        /// Method for removing hotels
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Hotel RemoveHotel(int id)
        {
            return _hotelRepo.Delete(id);
        }


        /// <summary>
        /// Method for update branches
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public bool UpdateBranch(Branch branch)
        {
            return _branchRepo.Update(branch);
        }

        /// <summary>
        /// Method for update hotels
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public bool UpdateHotels(Hotel hotel)
        {
            return _hotelRepo.Update(hotel);
        }

        /// <summary>
        /// Method for Add hotels
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelDTO GetHotel(int id)
        {
            var hotel = GetAllHotelsDetails().FirstOrDefault(h => h.Hotel_id == id);
            if(hotel != null)
                return hotel;
            return null;
        }


        /// <summary>
        /// Method for get all the hotels within the price range
        /// </summary>
        /// <param name="maxprice"></param>
        /// <param name="minprice"></param>
        /// <returns></returns>
        public ICollection<HotelDTO> GetHotelInPriceRange(int maxprice , int minprice)
        {
            return GetAllHotelsDetails().Where(h => h.starting_price == maxprice && h.starting_price == minprice).ToList();
        }


        /// <summary>
        /// Method to get all the hotels with the given amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public ICollection<HotelDTO> GetHotelsOnAmenities(string amenities)
        {
            return GetAllHotelsDetails().Where(h => h.amenities.Contains(amenities)).ToList();
        }
        
        /// <summary>
        /// Method to get hotels based on their location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public ICollection<HotelDTO> GetHotelsOnLocation(string loc)
        {
            return GetAllHotelsDetails().Where(h => h.Hotel_address.Contains(loc)).ToList();
        }


        //Countability Functions
        /// <summary>
        /// Method to get number of hotels
        /// </summary>
        /// <returns></returns>
        public int NumberOfHotels()
        {
            return GetAllHotelsDetails().Count; 
        }

        /// <summary>
        /// Method to get number of hotels based on amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public int NumberOfHotelsOnAmenities(string amenities)
        {
            return GetHotelsOnAmenities(amenities).Count;
        }

        /// <summary>
        /// Method to get number of hotels based on location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public int NumberOfHotelsOnLocation(string loc)
        {
            return GetHotelsOnLocation(loc).Count;
        }

        /// <summary>
        /// Method to get number of hotels within given price ranges
        /// </summary>
        /// <param name="maxprice"></param>
        /// <param name="minprice"></param>
        /// <returns></returns>
        public int NumberOfHotelsOnPriceRange(int maxprice, int minprice)
        {
            return GetHotelInPriceRange(maxprice, minprice).Count;
        }

    }
}
