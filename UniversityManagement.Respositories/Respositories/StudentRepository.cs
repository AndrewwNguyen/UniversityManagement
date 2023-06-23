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
    public class StudentRepository :BaseReponsitory<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
           
        }
        public List<Student> GetAllStudentDepartment(int idDepartment)
        {
            return db.Set<Student>().Include(x=>x.Class).ThenInclude(a=>a.Deparment.IdDeparment == idDepartment).ToList();
        }
        public List<Student> GetAllStudentInClass(int idclass)
        {
            return db.Set<Student>().Where(x => x.IdClass == idclass).ToList();
        }

        public List<Student> GetAllStudentInSubject(int idSubject)
        {
            return db.Set<Student>().Include(x => x.Subject_Students.Where(x => x.IdSubject == idSubject)).ToList();
        }

        public Student GetStudentByName(string name)
        {
           Student student = db.Set<Student>().FirstOrDefault(x=>x.Name == name);
            return student;
        }

        public dynamic GetStudentWithClass()
        {
            return db.Set<Student>().Include(x => x.Class);
        }

        public dynamic GetStudentWithSubject()
        {
            return db.Set<Student>().Include(x=>x.Subject_Students).ThenInclude(x=>x.Subject);
        }

    }
}
