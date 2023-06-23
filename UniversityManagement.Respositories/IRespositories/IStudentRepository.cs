
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Student GetStudentByName(string name); 
        List<Student> GetAllStudentInClass(int idClass);
        List<Student> GetAllStudentInSubject(int idSubject);
        List<Student> GetAllStudentDepartment(int idDepartment);
        dynamic GetStudentWithClass();
        dynamic GetStudentWithSubject();
    }
}
