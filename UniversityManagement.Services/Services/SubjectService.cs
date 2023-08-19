
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Infrastructures;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddSubject(Subject entity)
        {
            _unitOfWork.subjectRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteSubject(Subject entity)
        {
            _unitOfWork.subjectRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteSubject(int entityId)
        {
            _unitOfWork.subjectRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public Subject Find(int entityId)
        {
            var subject = _unitOfWork.subjectRepository.Find(entityId);
            return subject;
        }

        public IEnumerable<Subject> GetAllEntities()
        {
            var subject = _unitOfWork.subjectRepository.GetAllEntities();
            return subject;
        }

        public Subject GetSubjectByName(string name)
        {
            var subject = _unitOfWork.subjectRepository.GetSubjectByName(name);
            return subject;
        }

        public IEnumerable<Subject> GetAllSubjectByStudent(string name)
        {
            var subject = _unitOfWork.subjectRepository.GetAllSubjectByStudent(name);
            return subject;
        }

        public void UpdateSubject(Subject entity)
        {
            _unitOfWork.subjectRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }
        public IEnumerable<Subject> SubjectPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.subjectRepository.Pagination(pageSize, PageIndex);
        }

        public IEnumerable<Subject> GetAllSubjectByStudentId(int StudentId)
        {
            var subject = _unitOfWork.subjectRepository.GetAllSubjectByStudentId(StudentId);
            return subject;
        }

        public IEnumerable<Subject> GetSubjectByTeacher(string teacherName)
        {
            var subject = _unitOfWork.subjectRepository.GetSubjectByTeacher(teacherName);
            return subject;
        }
    }
}
