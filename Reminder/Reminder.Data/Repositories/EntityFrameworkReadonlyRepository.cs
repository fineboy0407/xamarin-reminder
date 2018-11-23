using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reminder.Data.Core;

namespace Reminder.Data.Repositories
{
    public class EntityFrameworkReadonlyRepository<TContext> : IReadOnlyRepository<Entity>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EntityFrameworkReadonlyRepository(TContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<Entity> GetQueryable(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<Entity> query = Context.Set<Entity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IEnumerable<Entity> GetAll(
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public IEnumerable<Entity> Get(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public async Task<IEnumerable<Entity>> GetAsync(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public Entity GetOne(Expression<Func<Entity, bool>> filter = null,
            string includeProperties = null)
        {
            return GetQueryable(filter, null, includeProperties).SingleOrDefault();
        }

        public async Task<Entity> GetOneAsync(Expression<Func<Entity, bool>> filter = null, string includeProperties = null)
        {
            return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public Entity GetFirst(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null)
        {
            return GetQueryable(filter, orderBy, includeProperties).SingleOrDefault();
        }

        public async Task<Entity> GetFirstAsync(
            Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            string includeProperties = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties).SingleOrDefaultAsync();
        }

        public Entity GetById(object id)
        {
            return Context.Set<Entity>().Find(id);
        }

        public async Task<Entity> GetByIdAsync(object id)
        {
            return await Context.Set<Entity>().FindAsync(id);
        }

        public int GetCount(Expression<Func<Entity, bool>> filter = null)
        {
            return GetQueryable(filter).Count();
        }

        public Task<int> GetCountAsync(Expression<Func<Entity, bool>> filter = null)
        {
            return GetQueryable(filter).CountAsync();
        }

        public bool GetExists(Expression<Func<Entity, bool>> filter = null)
        {
            return GetQueryable(filter).Any();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<Entity, bool>> filter = null)
        {
            return await GetQueryable(filter).AnyAsync();
        }
    }
}