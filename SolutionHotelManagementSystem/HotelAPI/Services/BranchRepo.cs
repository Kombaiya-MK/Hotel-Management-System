using HotelAPI.Interfaces;
using HotelAPI.Models;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class BranchRepo : IRepo<Branch, int>
    {
        private readonly HotelContext _branches;

        public BranchRepo(HotelContext branches)
        {
            _branches = branches;
        }
        public bool Add(Branch item)
        {
            bool status = false;
            try
            {
                _branches.Branches.Add(item);
                _branches.SaveChanges();
                status = true;
            }
            catch (NoValueException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return status;
        }

        public Branch Delete(int key)
        {
            var branch = Get(key);
            if (branch != null)
            {
                _branches.Branches.Remove(branch);
                _branches.SaveChanges();
                return branch;
            }
            return null;
        }

        public Branch Get(int key)
        {
            var hotel = _branches.Branches.FirstOrDefault(b => b.Branch_Id == key);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
        }

        public ICollection<Branch> GetAll()
        {
            return _branches.Branches.ToList();
        }

        public bool Update(Branch item)
        {
            bool status = false;
            var branch = Get(item.Branch_Id);
            if (branch != null)
            {
                branch.Branch_Name = item.Branch_Name;
                branch.Branch_Location = item.Branch_Location;
                _branches.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}
