using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Infrastructures;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.Services.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddStudent(Student entity)
        {
            entity.DateOfCreation = DateTime.Now;
            entity.DateOfUpdate = DateTime.Now;
            _unitOfWork.studentRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteStudent(Student entity)
        {
            _unitOfWork.studentRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteStudent(int entityId)
        {
            _unitOfWork.studentRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public IEnumerable<Student> GetAllEntities()
        {
            var student = _unitOfWork.studentRepository.GetAllEntities();
            return student;
        }
        public IEnumerable<Student> GetStudentsBySubject(string subjectName)
        {
            var student = _unitOfWork.studentRepository.GetStudentsBySubject(subjectName);
            return student;
        }
        public Student GetStudentByName(string name)
        {
            var student = _unitOfWork.studentRepository.GetStudentByName(name);
            return student;
        }
        public IEnumerable<Student> GetStudentsBySubjectId(Guid subjectId)
        {
            var student = _unitOfWork.studentRepository.GetAllStudentInSubject(subjectId);
            return student;
        }
        public IEnumerable<Student> GetAllStudentInClass(Guid postId)
        {
            var student = _unitOfWork.studentRepository.GetAllStudentInClass(postId);
            return student;
        }

        public Student Find(Guid entityId)
        {
            var student = _unitOfWork.studentRepository.Find(entityId);
            return student;
        }

        public void UpdateStudent(Student entity)
        {
            entity.DateOfUpdate = DateTime.Now;
            _unitOfWork.studentRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public IEnumerable<Student> StudentPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.studentRepository.Pagination(pageSize, PageIndex);
        }
    }
}
