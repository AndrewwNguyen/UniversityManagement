using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Infrastructures;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.Services.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddClass(Class entity)
        {
            _unitOfWork.classRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteClass(Class entity)
        {
            _unitOfWork.classRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteClass(int entityId)
        {
            _unitOfWork.classRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public Class Find(Guid entityId)
        {
            var classes = _unitOfWork.classRepository.Find(entityId);
            return classes;
        }

        public IEnumerable<Class> GetAllEntities()
        {
            var classes = _unitOfWork.classRepository.GetAllEntities();
            return classes;
        }

        public Class GetClassByName(string name)
        {
            var classes = _unitOfWork.classRepository.GetClassByName(name);
            return classes;
        }

        public void UpdateClass(Class entity)
        {
            _unitOfWork.classRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public IEnumerable<Class> ClassPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.classRepository.Pagination(pageSize, PageIndex);
        }
    }
}
