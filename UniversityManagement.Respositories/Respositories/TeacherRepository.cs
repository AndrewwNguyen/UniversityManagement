using Microsoft.EntityFrameworkCore;
using UniversityManagement.Entities.Data;
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.IRespositories;

namespace UniversityManagement.Respositories.Respositories
{
    public class TeacherRepository : BaseReponsitory<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Teacher GetTeacherByName(string teacherName)
        {
            Teacher teacher = db.Set<Teacher>().FirstOrDefault(x => x.TeacherName == teacherName);
            return teacher;
        }

        public virtual IEnumerable<Teacher> GetAllEntities()
        {
            return db.Set<Teacher>().Include(x => x.Subjects).OrderBy(x => x.DateOfCreation).ToList();
        }
    }
}
