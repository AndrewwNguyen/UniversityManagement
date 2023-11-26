using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities.Models
{
    public class Class : BaseModel
    {
        [Key]
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public DateTime YearOfAdmission { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<Student>? Students {get;set;}
        public string? Description { get; set; }
    }
}
