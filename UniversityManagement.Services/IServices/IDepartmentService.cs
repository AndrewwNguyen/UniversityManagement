using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IDepartmentService
    {
        Department Find(int entityId);
        void AddDepartment(Department entity);
        void UpdateDepartment(Department entity);
        void DeleteDepartment(Department entity);
        void DeleteDepartment(int entityId);
        IEnumerable<Department> GetAllEntities();
        Department GetDepartmentByName(string name);
        public IEnumerable<Department> DepartmentPagination(int pageSize, int PageIndex);

    }
}
