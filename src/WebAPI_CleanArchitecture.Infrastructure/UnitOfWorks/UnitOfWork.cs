using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Infrastructure.Repositories;

namespace WebAPI_CleanArchitecture.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {

        public async Task<string> CommitAsync(CancellationToken cancellationToken = default, bool CheckForConcurrency = false)
        {
            try
            {
                // cancellationToken: if the user ends the specific operation, 
                // this ensures the database task is aborted to save resources
                await _context.SaveChangesAsync(cancellationToken);
            }

            // the Concurrency work with RowVersion
            catch(DbUpdateConcurrencyException) when(CheckForConcurrency)
            {
                return "A concurrency conflict occurred while saving changes";
            }

            return string.Empty;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        => new GenericRepository<TEntity>(_context);
    }
}
