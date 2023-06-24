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
    public class StudentRepository : BaseReponsitory<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public List<Student> GetAllStudentDepartment(int departmentId)
        {
            return db.Set<Student>().Include(x => x.Class).ThenInclude(a => a.Deparment.DeparmentId == departmentId).ToList();
        }
        public List<Student> GetAllStudentInClass(int classId)
        {
            return db.Set<Student>().Where(x => x.ClassId == classId).ToList();
        }

        public List<Student> GetAllStudentInSubject(int subjectId)
        {
            return db.Set<Student>().Include(x => x.Subject_Students.Where(x => x.SubjectId == subjectId)).ToList();
        }
        public List<Student> GetStudentsBySubject(string subjectName)
        {
            return db.Set<Student>().Include(x => x.Subject_Students).ThenInclude(x => x.Subject.SubjectName == subjectName).ToList();
        }
        public Student GetStudentByName(string studentName)
        {
            Student student = db.Set<Student>().FirstOrDefault(x => x.StudentName == studentName);
            return student;
        }
        public dynamic GetStudentWithClass()
        {
            return db.Set<Student>().Include(x => x.Class);
        }
        public dynamic GetStudentWithSubject()
        {
            return db.Set<Student>().Include(x => x.Subject_Students).ThenInclude(x => x.Subject);
        }
    }
}
