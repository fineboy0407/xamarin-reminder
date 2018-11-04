using System;
using System.Data.Entity;
using System.Linq;
using Reminder.Data.Entities;

namespace Reminder.Data
{
    public class Repository<TEntity> : IDisposable
        where TEntity : Entity
    {
        private readonly DbContext _dbContext;
        private bool _disposed = false;

        protected IDbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Create(TEntity item)
        {
            DbSet.Add(item);
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = DbSet.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
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