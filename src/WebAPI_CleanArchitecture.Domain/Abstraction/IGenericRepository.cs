namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancelationToken = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancelationToken = default);
        Task CreateRangeAsync(IEnumerable<TEntity> entityCollection, CancellationToken cancelationToken = default);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> enittyCollection);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entityCollection);

    }
}
