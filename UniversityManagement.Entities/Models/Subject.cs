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
        [ForeignKey("ClassRoom")]
        public int IdSubject { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Subject_Student>? Subject_Students { get;set; }
        public virtual ICollection<Subject_Score>? Subject_Score { get; set; }
        public virtual ClassRoom? ClassRoom { get; set; }
    }
}
