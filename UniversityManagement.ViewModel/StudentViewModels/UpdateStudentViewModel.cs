using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.ViewModel.StudentViewModels
{
    public class UpdateStudentViewModel
    {
        public string? StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
    }
}
