using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.Entities.Models
{
    public class Teacher : BaseModel
    {
        [Key]
        public Guid TeacherId { get; set; }
        public string? TeacherName { get; set; }        
        public string? Description { get; set; }
        public virtual ICollection<Subject>? Subjects { get; set; } = new List<Subject>();

    }
}
