namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        // << Signature Of Methods >>

        Task<string> CommitAsync(CancellationToken cancellationToken = default, bool CheckForConcurrency = false);
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
