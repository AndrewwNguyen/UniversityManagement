using UniversityManagement.Entities.Data;
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.IRespositories;

namespace UniversityManagement.Respositories.Respositories
{
    public class DepartmentRepository : BaseReponsitory<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Department GetDepartmentByName(string departmentName)
        {
            Department department = db.Set<Department>().FirstOrDefault(x => x.DepartmentName == departmentName);
            return department;
        }
        public override IEnumerable<Department> GetAllEntities()
        {
            return db.Set<Department>().OrderBy(x => x.DateOfCreation).ToList();
        }
    }
}
