using UniversityManagement.Entities.Models;

namespace UniversityManagement.API.Models
{
    public class LoginResponseAPI
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
