using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reminder.Data.Core;

namespace Reminder.Data.Repositories
{
    public class EntityFrameworkRepository<TContext> : EntityFrameworkReadonlyRepository<TContext>, IRepository<Entity>
        where TContext : DbContext
    {
        public EntityFrameworkRepository(TContext context)
            : base(context)
        {
        }

        public void Create(Entity entity)
        {
            Context.Set<Entity> ().Add(entity);
        }

        public void Update(Entity entity)
        {
            Context.Set<Entity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Entity entity = Context.Set<Entity>().Find(id);
            Delete(entity);
        }

        public void Delete(Entity entity)
        {
            var dbSet = Context.Set<Entity>();
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}