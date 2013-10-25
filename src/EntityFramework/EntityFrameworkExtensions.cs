using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Takenet.Library.Data.EntityFramework
{
    public static class EntityFrameworkExtensions
    {
        public static IEnumerable<T> Include<T>(this IEnumerable<T> source, string path)
        {
            var objectQuery = source as ObjectQuery<T>;
            if (objectQuery != null)
            {
                return objectQuery.Include(path);
            }
            return source.AsQueryable();
        }

        public static IEnumerable<T> NoTracking<T>(this IEnumerable<T> source) where T : class
        {
            var objectQuery = source as IQueryable<T>;
            if (objectQuery != null)
            {
                return objectQuery.AsNoTracking<T>();
            }
            return source;
        }

        public static void Attach<TEntity, TId>(this EntityRepository<TEntity, TId> repository, TEntity entity)
            where TEntity : class
        {
            repository._context.Set<TEntity>().Attach(entity);
        }

        public static void Detach<TEntity, TId>(this EntityRepository<TEntity, TId> repository, TEntity entity)
            where TEntity : class
        {
            repository._context.Entry<TEntity>(entity).State = EntityState.Detached;
        }
    }
}
