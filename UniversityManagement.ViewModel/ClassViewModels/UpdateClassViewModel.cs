using UniversityManagement.Entities.Models;

namespace UniversityManagement.ViewModel.ClassViewModels
{
    public class UpdateClassViewModel
    {
        public string ClassName { get; set; }
        public virtual Department? Department { get; set; }
        public string? Description { get; set; }
    }
}
