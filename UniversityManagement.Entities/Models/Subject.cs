using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities.Models
{
    public class Subject : BaseModel
    {
        [Key]
        public Guid SubjectId { get; set; }
        [Required]
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Subject_Student>? Subject_Student { get;set; }
        public virtual ICollection<Subject_Classroom>? Subject_Classroom { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
