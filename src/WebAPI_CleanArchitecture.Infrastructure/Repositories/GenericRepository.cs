using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext _context) :
        IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// AsQueryable: Allows further filtering, sorting, or paging 
        /// to be translated into SQL and executed on the database side.
        /// ASNoTracking => ReadOnly, AsQueryable => 
        /// </summary>
        public IQueryable<TEntity> GetAll()
        => _context.Set<TEntity>().AsNoTracking().AsQueryable();
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Set<TEntity>().FindAsync([id, cancellationToken], cancellationToken);



        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entityCollection, CancellationToken cancellationToken = default)
        => await _context.Set<TEntity>().AddRangeAsync(entityCollection, cancellationToken);




        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return entity;
        }
        public void UpdateRange(IEnumerable<TEntity> entityCollection)
        {
            _context.Set<TEntity>().UpdateRange(entityCollection);
        }



        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entityCollection)
        {
            _context.Set<TEntity>().RemoveRange(entityCollection);
        }



    }
}
