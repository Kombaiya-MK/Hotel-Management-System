using System.Diagnostics;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserRepo : IBaseRepo<string, User>
    {
        private readonly JWTContext _context;

        public UserRepo(JWTContext context)
        {
            _context = context;
        }
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return item;
        }

        public User Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == key);
            if (user == null)
            {
                return null;
            }
            return user;
        }

    }
}
