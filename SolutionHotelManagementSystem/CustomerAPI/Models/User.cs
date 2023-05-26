using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? HashKey { get; set; }

        public string? UserPhoneNumber { get; set; }

        public string Usermailid { get; set; }

        public int UsetAge { get; set; }
        public string? UserRole { get; set; }


    }
}
