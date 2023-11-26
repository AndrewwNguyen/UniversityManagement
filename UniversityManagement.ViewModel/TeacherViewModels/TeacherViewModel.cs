namespace UniversityManagement.ViewModel.TeacherViewModels
{
    public class TeacherViewModel
    {
        public Guid TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public string? Description { get; set; }
        public ICollection<string> SubjectName { get; set; }
        public string DepartmentName { get; set; }
    }
}
