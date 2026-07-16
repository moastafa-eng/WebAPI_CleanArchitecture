using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Exceptions;
using WebAPI_CleanArchitecture.Infrastructure.Repositories;

namespace WebAPI_CleanArchitecture.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {

        public async Task CommitAsync(CancellationToken cancellationToken = default, bool CheckForConcurrency = false)
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
                throw new ConcurrencyException(["A Concurrency exception occurred while saving changes"]);
            }
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        => new GenericRepository<TEntity>(_context);
    }
}
