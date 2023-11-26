using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
        public Department GetDepartmentByName(string name);
        public IEnumerable<Department> GetAllEntities();
    }
}
