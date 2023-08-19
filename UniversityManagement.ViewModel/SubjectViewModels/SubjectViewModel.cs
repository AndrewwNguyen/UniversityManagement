using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.ViewModel.SubjectViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
    }
}
