using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface ISubjectService
    {
        Subject Find(Guid entityId);
        void AddSubject(Subject entity);
        void UpdateSubject(Subject entity);
        void DeleteSubject(Subject entity);
        void DeleteSubject(int entityId);
        IEnumerable<Subject> GetAllEntities();
        Subject GetSubjectByName(string name);
        IEnumerable<Subject> GetAllSubjectByStudent(string name);
        IEnumerable<Subject> GetAllSubjectByStudentId(Guid StudentId);
        public IEnumerable<Subject> SubjectPagination(int pageSize, int PageIndex);
        public IEnumerable<Subject> GetSubjectByTeacher(string stringName);
    }
}
