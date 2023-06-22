using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set;}
        [ForeignKey("Class")]
        public int IdClass { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<Subject_Student>? Subject_Students { get; set; }
        public virtual ICollection<Subject_Score>? Subject_Scores { get; set; }

    }
}
