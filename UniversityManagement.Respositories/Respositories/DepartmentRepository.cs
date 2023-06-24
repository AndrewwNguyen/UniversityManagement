using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Department department = db.Set<Department>().FirstOrDefault(x => x.DeparmentName == departmentName);
            return department;
        }
    }
}
