using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface ITeacherService
    {
        Teacher Find(int entityId);
        void AddTeacher(Teacher entity);
        void UpdateTeacher(Teacher entity);
        void DeleteTeacher(Teacher entity);
        void DeleteTeacher(int entityId);
        IEnumerable<Teacher> GetAllEntities();
        Teacher GetTeacherByName(string name);
    }
}
