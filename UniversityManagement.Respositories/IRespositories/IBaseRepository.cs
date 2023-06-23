using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Respositories.Infrastructures;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Find(int entityId);
        void AddTEntity(TEntity entity);
        void UpdateTEntity(TEntity entity);
        void DeleteTEntity(TEntity entity);
        void DeleteTEntity(int entityId);
        IEnumerable<TEntity> GetAllEntities();
        IEnumerable<TEntity> Pagination(int pageSize, int pageIndex);
    }
}
