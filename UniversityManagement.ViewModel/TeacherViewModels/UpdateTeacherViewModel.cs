using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.ViewModel.TeacherViewModels
{
    public class UpdateTeacherViewModel
    {
        public string? TeacherName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Subject>? Subjects { get; set; }
    }
}
