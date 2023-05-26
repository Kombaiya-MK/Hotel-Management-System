using UserAPI.Models.UserDTO;

namespace UserAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }

}
