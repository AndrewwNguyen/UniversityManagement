using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Student GetStudentByName(string name); 
        List<Student> GetAllStudentInClass(Guid idClass);
        List<Student> GetAllStudentInSubject(Guid idSubject);
        List<Student> GetStudentsBySubject(string subjectName);
        List<Student> GetAllStudentDepartment(Guid idDepartment);
        dynamic GetStudentWithClass();
        dynamic GetStudentWithSubject();
        public IEnumerable<Student> GetAllEntities();
    }
}
