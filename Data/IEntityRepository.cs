using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Takenet.Library.Data
{
    /// <summary>
    /// Base interface for entities repositories
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Type of entity id (key) member</typeparam>
    public interface IEntityRepository<TEntity, TId> where TEntity : class
    {
        /// <summary>
        /// Adds a <typeparamref name="TEntity"/> to the repository
        /// </summary>
        /// <param name="entity">Entity instance to add on repository</param>
        /// <param name="isNew">Indicates if the entity is new or a existing value</param>
        void Add(TEntity entity, bool isNew);

        /// <summary>
        /// Removes a existing <typeparamref name="TEntity"/> from the repository
        /// </summary>
        /// <param name="entity">Entity instance to remove from repository</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Gets a collection of <typeparamref name="TEntity"/> with all entities on the repository
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use AsQueryable instead")]
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get a instance of <typeparamref name="TEntity"/> by entity key
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        TEntity GetById(TId id);

        /// <summary>
        /// Gets a generic IQueryable member
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> AsQueryable();
    }
}
