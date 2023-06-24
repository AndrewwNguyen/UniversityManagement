using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        public Teacher GetTeacherBySubject(string subjectName);
        public Teacher GetTeacherByName(string teacherName);
    }
}
