using System.Linq;
using System.Threading.Tasks;
using Reminder.Data.Entities;

namespace Reminder.Data.Abstract
{
    /// <summary>
    /// Provide CRUD functionality of the <see cref="Entity"/> items.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Return all <see cref="Entity"/> by id.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Create <see cref="Entity"/> and save it.
        /// </summary>
        /// <param name="item">item to be created.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity item);

        /// <summary>
        /// Get <see cref="Entity"/> by id.
        /// </summary>
        /// <param name="id">id of the entity.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Update <see cref="Entity"/> item and save changes.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity item);

        /// <summary>
        /// Delete <see cref="Entity"/> item and save changes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}