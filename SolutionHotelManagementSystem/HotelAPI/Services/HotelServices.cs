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
        public bool AddHotel(Hotel hotel)
        {
            var branch = _branchRepo.Get(hotel.Branch_id);
            if (branch != null)
                return _hotelRepo.Add(hotel);
            return false;
        }

        public bool AddBranch(Branch branch)
        {
            return _branchRepo.Add(branch); 
        }

        public Branch RemoveBranch(int id)
        {
            return _branchRepo.Delete(id);
        }

        public Hotel RemoveHotel(int id)
        {
            return _hotelRepo.Delete(id);
        }

        public bool UpdateBranch(Branch branch)
        {
            return _branchRepo.Update(branch);
        }

        public bool UpdateHotels(Hotel hotel)
        {
            return _hotelRepo.Update(hotel);
        }

        public HotelDTO GetHotel(int id)
        {
            var hotel = GetAllHotelsDetails().FirstOrDefault(h => h.Hotel_id == id);
            if(hotel != null)
                return hotel;
            return null;
        }

        public ICollection<HotelDTO> GetHotelInPriceRange(int maxprice , int minprice)
        {
            return GetAllHotelsDetails().Where(h => h.starting_price == maxprice && h.starting_price == minprice).ToList();
        }

        public ICollection<HotelDTO> GetHotelsOnAmenities(string amenities)
        {
            return GetAllHotelsDetails().Where(h => h.amenities.Contains(amenities)).ToList();
        }

        public ICollection<HotelDTO> GetHotelsOnLocation(string loc)
        {
            return GetAllHotelsDetails().Where(h => h.Hotel_address.Contains(loc)).ToList();
        }
    }
}
