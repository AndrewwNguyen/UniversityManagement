using UniversityManagement.Entities.Enum;

namespace UniversityManagement.Entities.Models
{
    public class BaseModel
    {
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public Status? Status { get; set; }
    }
}
