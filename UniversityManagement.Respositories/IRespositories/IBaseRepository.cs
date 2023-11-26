namespace UniversityManagement.Respositories.IRespositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Find(Guid entityId);
        void AddTEntity(TEntity entity);
        void UpdateTEntity(TEntity entity);
        void DeleteTEntity(TEntity entity);
        void DeleteTEntity(int entityId);
        IEnumerable<TEntity> Pagination(int pageSize, int pageIndex);
    }
}
