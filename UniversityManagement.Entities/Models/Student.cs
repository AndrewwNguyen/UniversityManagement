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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set;}
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<Subject_Student>? Subject_Students { get; set; }
        public string? Description { get; set; }    

    }
}
