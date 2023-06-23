
using Microsoft.EntityFrameworkCore;
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
            return db.Set<Subject>().Include(x => x.Subject_Student).ThenInclude(x => x.Student.Name == studentName).ToList();
        }
        public List<Subject> GetAllSubjectByStudentId(int StudentId)
        {
            return db.Set<Subject>().Include(x => x.Subject_Student).ThenInclude(x => x.Student.IdStudent == StudentId).ToList();
        }
    }
}
