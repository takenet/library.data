using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Takenet.Library.Data;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace Takenet.Library.Data.EntityFramework
{
    /// <summary>
    /// Base class that implements IEntityRepository for
    /// EntityFramework
    /// </summary>
    /// <typeparam name="TEntity">Type of entity repository</typeparam>
    /// <typeparam name="TId">Type of entity unique ID</typeparam>
    public abstract class EntityRepository<TEntity, TId> : IEntityRepository<TEntity, TId> where TEntity : class
    {
        protected internal readonly DbContext _context;
        /// <summary>
        /// Instantiate a new repository
        /// </summary>
        /// <param name="context"></param>
        public EntityRepository(DbContext context)
        {
            _context = context;

            var objectContext = (this._context as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = this._context.Database.Connection.ConnectionTimeout;            
        }

        #region IEntityRepository<TEntity,TId> Members

        /// <summary>
        /// Adds a <typeparamref name="TEntity"/> to the repository
        /// </summary>
        /// <param name="entity">Entity instance to add on repository</param>
        /// <param name="isNew">Indicates if the entity is new or a existing value</param>
        public virtual void Add(TEntity entity, bool isNew)
        {
            if (isNew)
            {
                _context.Set<TEntity>().Add(entity);
            }
            else
            {
                if (_context.Entry<TEntity>(entity).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(entity);
                }
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Removes a existing <typeparamref name="TEntity"/> from the repository
        /// </summary>
        /// <param name="entity">Entity instance to remove from repository</param>
        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Gets a collection of <typeparamref name="TEntity"/> with all entities on the repository
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use AsQueryable instead")]
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Get a instance of <typeparamref name="TEntity"/> by entity key
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns></returns>
        public virtual TEntity GetById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Gets a generic <typeparamref name="TEntity"/> IQueryable member
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>();
        }

        #endregion
    }
}
