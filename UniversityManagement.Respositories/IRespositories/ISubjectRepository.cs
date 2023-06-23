
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface ISubjectRepository:IBaseRepository<Subject>
    {
        List<Subject> GetAllSubjectByStudent(string studentName);
        List<Subject> GetAllSubjectByStudentId(int StudentId);
        public Subject GetSubjectByName(string name);

    }
}
