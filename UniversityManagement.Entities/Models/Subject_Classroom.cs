using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Subject_Classroom
    {
        public int IdRoom { get; set; }
        public int IdSubject { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public string? Description { get; set; }
    }
}
