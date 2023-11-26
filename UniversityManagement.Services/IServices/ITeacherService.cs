using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface ITeacherService
    {
        Teacher Find(Guid entityId);
        void AddTeacher(Teacher entity);
        void UpdateTeacher(Teacher entity);
        void DeleteTeacher(Teacher entity);
        void DeleteTeacher(int entityId);
        IEnumerable<Teacher> GetAllEntities();
        Teacher GetTeacherByName(string name);
    }
}
