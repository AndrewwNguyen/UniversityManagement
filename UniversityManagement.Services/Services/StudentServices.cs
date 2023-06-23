using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Infrastructures;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.Services.Services
{
    public class StudentServices:IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddStudent(Student entity)
        {
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
        public Student Find(int entityId)
        {
            var category = _unitOfWork.studentRepository.Find(entityId);
            return category;
        }

        public IEnumerable<Student> GetAllEntities()
        {
            var categorys = _unitOfWork.studentRepository.GetAllEntities();
            return categorys;
        }

        public Student GetStudentByName(string name)
        {
            var category = _unitOfWork.studentRepository.GetStudentByName(name);
            return category;
        }

        public IEnumerable<Student> GetAllStudentInClass(int postId)
        {
            var categories = _unitOfWork.studentRepository.GetAllStudentInClass(postId);
            return categories;
        }

        public void UpdateStudent(Student entity)
        {
            _unitOfWork.studentRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }
        public IEnumerable<Student> StudentPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.studentRepository.Pagination(pageSize, PageIndex);
        }
    }
}
