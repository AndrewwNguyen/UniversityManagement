using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        public Teacher GetTeacherByName(string teacherName);
        public IEnumerable<Teacher> GetAllEntities();
    }
}
