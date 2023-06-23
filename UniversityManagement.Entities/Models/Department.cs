using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Department
    {
        [Key]
        public int DeparmentId { get; set; }
        public string? DeparmentName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Class>? Classes { get; set; }
    }
}
