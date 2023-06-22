using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClass { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Deparment")]
        public int IdDeparment { get; set; }
        public virtual Deparment Deparment { get; set; }
        public DateTime YearOfAdmission { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<Student> Students {get;set;}

        //Branch 1
    }
}
