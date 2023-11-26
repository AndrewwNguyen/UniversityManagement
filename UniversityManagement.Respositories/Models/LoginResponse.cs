using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.Models
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
