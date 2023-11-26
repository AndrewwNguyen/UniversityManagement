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
    public class ClassRepository : BaseReponsitory<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Class GetClassByName(string className)
        {
            Class classes = db.Set<Class>().FirstOrDefault(x => x.ClassName == className);
            return classes;
        }
        public override IEnumerable<Class> GetAllEntities()
        {
            return db.Set<Class>().OrderBy(x => x.DateOfCreation).ToList();
        }
    }
}
