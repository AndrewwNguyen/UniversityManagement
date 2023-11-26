namespace UniversityManagement.ViewModel.StudentViewModels
{
    public class StudentViewModel
    {
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? ClassName { get; set; }
        public ICollection<string> SubjectName { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public string Status { get; set; }
    }
}
