
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UniversityManagement.Entities.Data;
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.IRespositories;

namespace UniversityManagement.Respositories.Respositories
{
    public class SubjectRepository : BaseReponsitory<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {

        }
        public List<Subject> GetAllSubjectByStudent(string studentName)
        {
            return db.Set<Subject>().Include(x => x.Subject_Student).ThenInclude(x => x.Student.StudentName == studentName).ToList();
        }
        public List<Subject> GetAllSubjectByStudentId(int StudentId)
        {
            return db.Set<Subject>().Include(x => x.Subject_Student).ThenInclude(x => x.Student.StudentId == StudentId).ToList();
        }

        public Subject GetSubjectByName(string subjectName)
        {
            Subject subject = db.Set<Subject>().FirstOrDefault(x => x.SubjectName == subjectName);
            return subject;
        }

        public List<Subject> GetSubjectByTeacher(string teacherName)
        {
            return db.Set<Subject>().Where(x => x.Teacher.TeacherName.Contains(teacherName)).ToList();
        }

        public virtual IEnumerable<Subject> GetAllEntities()
        {
            return db.Set<Subject>().Include(x=>x.Teacher).ToList();
        }
    }
}
