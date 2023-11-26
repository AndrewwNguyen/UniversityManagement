using UniversityManagement.Entities.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IClassService
    {
        Class Find(Guid entityId);
        void AddClass(Class entity);
        void UpdateClass(Class entity);
        void DeleteClass(Class entity);
        void DeleteClass(int entityId);
        IEnumerable<Class> GetAllEntities();
        Class GetClassByName(string name);
        public IEnumerable<Class> ClassPagination(int pageSize, int PageIndex);
    }
}
