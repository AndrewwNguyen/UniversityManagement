using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Subject_Student>? Subject_Student { get;set; }
        public virtual ICollection<Subject_Classroom>? Subject_Classroom { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
