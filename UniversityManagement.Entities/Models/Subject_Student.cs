using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Enum;

namespace UniversityManagement.Entities.Models
{
    public class Subject_Student 
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set;}   
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
        public float? Mark { get; set; }
        public string? Description { get; set; }
        public Status? Status { get; set; }
    }
}
