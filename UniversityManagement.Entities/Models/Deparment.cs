using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Deparment
    {
        [Key]
        public int IdDeparment { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Class>? Classes { get; set; }
    }
}
