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
