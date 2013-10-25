using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takenet.Library.Data.EntityFramework
{
    /// <summary>
    /// Base class that implements IEntityRepositoryAsync for
    /// EntityFramework
    /// </summary>
    /// <typeparam name="TEntity">Type of entity repository</typeparam>
    /// <typeparam name="TId">Type of entity unique ID</typeparam>
    public abstract class EntityRepositoryAsync<TEntity, TId> : IEntityRepositoryAsync<TEntity, TId> where TEntity : class
    {
        protected internal readonly DbContext _context;
        /// <summary>
        /// Instantiate a new repository
        /// </summary>
        /// <param name="context"></param>
        public EntityRepositoryAsync(DbContext context)
        {
            _context = context;

            var objectContext = (this._context as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = this._context.Database.Connection.ConnectionTimeout;           
        }

        #region IEntityRepositoryAsync<TEntity,TId> Members

        public virtual Task<TEntity> AddAsync(TEntity entity, bool isNew)
        {
            TEntity addedEntity;

            if (isNew)
            {
                addedEntity = _context.Set<TEntity>().Add(entity);
            }
            else
            {
                if (_context.Entry<TEntity>(entity).State == EntityState.Detached)
                {
                    addedEntity = _context.Set<TEntity>().Attach(entity);
                }
                else
                {
                    addedEntity = entity;
                }

                _context.Entry<TEntity>(entity).State = EntityState.Modified;
            }

            return Task.FromResult<TEntity>(addedEntity);
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.FromResult<object>(null);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {            
            // Task is not convariant
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(TId id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>();
        }

        #endregion
    }
}
