using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        public Class GetClassByName(string name);
        public IEnumerable<Class> GetAllEntities();
    }
}
