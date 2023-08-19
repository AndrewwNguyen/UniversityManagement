using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.ViewModel.StudentViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string ClassName { get; set; }
        public ICollection<string> SubjectName { get; set; }
    }
}
