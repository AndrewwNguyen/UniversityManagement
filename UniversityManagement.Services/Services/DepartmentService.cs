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
    public class DepartmentService:IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddDepartment(Department entity)
        {
            _unitOfWork.departmentRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteDepartment(Department entity)
        {
            _unitOfWork.departmentRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteDepartment(int entityId)
        {
            _unitOfWork.departmentRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public Department Find(int entityId)
        {
            var department = _unitOfWork.departmentRepository.Find(entityId);
            return department;
        }

        public IEnumerable<Department> GetAllEntities()
        {
            var department = _unitOfWork.departmentRepository.GetAllEntities();
            return department;
        }
        public Department GetDepartmentByName(string name)
        {
            var department = _unitOfWork.departmentRepository.GetDepartmentByName(name);
            return department;
        }
        public void UpdateDepartment(Department entity)
        {
            _unitOfWork.departmentRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }
        public IEnumerable<Department> DepartmentPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.departmentRepository.Pagination(pageSize, PageIndex);
        }
    }
}
