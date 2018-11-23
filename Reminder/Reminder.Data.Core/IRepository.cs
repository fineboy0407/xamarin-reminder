using System.Threading.Tasks;

namespace Reminder.Data.Core
{
    /// <summary>
    /// Provide CRUD methods for datasource.
    /// </summary>
    /// <typeparam name="TEntity">Entity type that inherit <see cref="IEntity{T}"/></typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Save();

        Task SaveAsync();
    }
}