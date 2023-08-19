using Microsoft.EntityFrameworkCore;
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

        public Teacher GetTeacherBySubject(string subjectName)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<Teacher> GetAllEntities()
        {
            return db.Set<Teacher>().Include(x => x.Subjects).ToList();
        }
    }
}
