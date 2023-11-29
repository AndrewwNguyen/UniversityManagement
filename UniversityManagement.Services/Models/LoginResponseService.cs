using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.Models
{
    public class LoginResponseService
    {
        public User User { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
