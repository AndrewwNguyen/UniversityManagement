using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface ISubjectService
    {
        Subject Find(int entityId);
        void AddSubject(Subject entity);
        void UpdateSubject(Subject entity);
        void DeleteSubject(Subject entity);
        void DeleteSubject(int entityId);
        IEnumerable<Subject> GetAllEntities();
        Subject GetSubjectByName(string name);
        IEnumerable<Subject> GetAllSubjectByStudent(string name);
        IEnumerable<Subject> GetAllSubjectByStudentId(int StudentId);
        public IEnumerable<Subject> SubjectPagination(int pageSize, int PageIndex);
        public IEnumerable<Subject> GetSubjectByTeacher(string stringName);
    }
}
