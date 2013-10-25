using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takenet.Library.Data
{
    /// <summary>
    /// Base interface for entities repositories
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Type of entity id (key) member</typeparam>
    public interface IEntityRepositoryAsync<TEntity, TId> where TEntity : class
    {
        /// <summary>
        /// Adds a <typeparamref name="TEntity"/> to the repository
        /// </summary>
        /// <param name="entity">Entity instance to add on repository</param>
        /// <param name="isNew">Indicates if the entity is new or a existing value</param>
        Task<TEntity> AddAsync(TEntity entity, bool isNew);

        /// <summary>
        /// Removes a existing <typeparamref name="TEntity"/> from the repository
        /// </summary>
        /// <param name="entity">Entity instance to remove from repository</param>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Gets a collection of <typeparamref name="TEntity"/> with all entities on the repository
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get a instance of <typeparamref name="TEntity"/> by entity key
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TId id);

        /// <summary>
        /// Gets a generic IQueryable member.
        /// AsQueryable is not async because it not
        /// represents an IO operation, since the query
        /// is built in memory. The submission of an IQueryable 
        /// object (i.e. calling ToList() method) should be async.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> AsQueryable();
    }
}
