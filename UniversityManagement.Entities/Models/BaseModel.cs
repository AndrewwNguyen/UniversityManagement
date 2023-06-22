using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Enum;

namespace UniversityManagement.Entities.Models
{
    public class BaseModel
    {
        public DateTime CreateAt { get; set; }
        public DateTime Modify { get; set; }
        public Status Status { get; set; }
    }
}
