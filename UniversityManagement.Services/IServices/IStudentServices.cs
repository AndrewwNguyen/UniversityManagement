using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IStudentServices
    {
        Student Find(Guid entityId);
        void AddStudent(Student entity);
        void UpdateStudent(Student entity);
        void DeleteStudent(Student entity);
        void DeleteStudent(int entityId);
        IEnumerable<Student> GetAllEntities();
        Student GetStudentByName(string name);
        IEnumerable<Student> GetAllStudentInClass(Guid ClassId);
        IEnumerable<Student> GetStudentsBySubject(string subjectName);
        public IEnumerable<Student> StudentPagination(int pageSize, int PageIndex);
        IEnumerable<Student> GetStudentsBySubjectId(Guid subjectId);
    }
}
