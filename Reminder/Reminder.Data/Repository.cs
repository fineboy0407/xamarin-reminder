using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Reminder.Data.Abstract;
using Reminder.Data.Entities;

namespace Reminder.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        protected IDbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task CreateAsync(TEntity item)
        {
            DbSet.Add(item);
            await SaveAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}