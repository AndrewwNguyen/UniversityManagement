using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Subject_Student
    {
        public int IdStudent { get; set; }
        public int IdSubject { get; set;}   
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}
