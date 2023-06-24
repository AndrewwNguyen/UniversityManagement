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
    public class TeacherService:ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddTeacher(Teacher entity)
        {
            _unitOfWork.teacherRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteTeacher(Teacher entity)
        {
            _unitOfWork.teacherRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteTeacher(int entityId)
        {
            _unitOfWork.teacherRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public Teacher Find(int entityId)
        {
            var subject = _unitOfWork.teacherRepository.Find(entityId);
            return subject;
        }

        public IEnumerable<Teacher> GetAllEntities()
        {
            var subject = _unitOfWork.teacherRepository.GetAllEntities();
            return subject;
        }

        public Teacher GetTeacherByName(string name)
        {
            var subject = _unitOfWork.teacherRepository.GetTeacherByName(name);
            return subject;
        }
        public void UpdateTeacher(Teacher entity)
        {
            _unitOfWork.teacherRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }
        public IEnumerable<Teacher> TeacherPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.teacherRepository.Pagination(pageSize, PageIndex);
        }

    }
}
