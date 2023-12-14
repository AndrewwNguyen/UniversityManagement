using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities.Models
{
    public class User : BaseModel
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
        public string? Description { get; set; }    
    }
}
