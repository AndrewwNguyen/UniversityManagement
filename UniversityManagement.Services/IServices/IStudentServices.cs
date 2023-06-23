using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IStudentServices
    {
        Student Find(int entityId);
        void AddStudent(Student entity);
        void UpdateStudent(Student entity);
        void DeleteStudent(Student entity);
        void DeleteStudent(int entityId);
        IEnumerable<Student> GetAllEntities();
        Student GetStudentByName(string name);
        IEnumerable<Student> GetAllStudentInClass(int ClassId);
        public IEnumerable<Student> StudentPagination(int pageSize, int PageIndex);
    }
}
