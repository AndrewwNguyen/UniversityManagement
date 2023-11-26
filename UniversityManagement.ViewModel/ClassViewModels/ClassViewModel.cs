using UniversityManagement.Entities.Models;

namespace UniversityManagement.ViewModel.ClassViewModels
{
    public class ClassViewModel
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public string? Description { get; set; }
    }
}
