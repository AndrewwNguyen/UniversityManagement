namespace UniversityManagement.Respositories.Models
{
    public class RegisterationRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
