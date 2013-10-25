using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace Takenet.Library.Data.EntityFramework
{
    /// <summary>
    /// Implements IUnitOfWork interface for Entity Framework DbContext class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
    public abstract class UnitOfWorkDbContextAsync : DbContext, IUnitOfWorkAsync
    {
        #region Constructors
        
        /// <summary>
        /// Constructs a new context instance using conventions to create the name of
        /// the database to which a connection will be made. The by-convention name is
        /// the full name (namespace + class name) of the derived context class.  See
        /// the class remarks for how this is used to create a connection.
        /// </summary>
        public UnitOfWorkDbContextAsync()
        {

        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made.  See the class
        /// remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public UnitOfWorkDbContextAsync(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }


        /// <summary>
        /// Constructs a new context instance using conventions to create the name of
        /// the database to which a connection will be made, and initializes it from
        /// the given model.  The by-convention name is the full name (namespace + class
        /// name) of the derived context class.  See the class remarks for how this is
        /// used to create a connection.
        /// </summary>
        /// <param name="dbCompiledModel"></param>
        public UnitOfWorkDbContextAsync(DbCompiledModel dbCompiledModel)
            : base(dbCompiledModel)
        {

        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made, and initializes
        /// it from the given model.  See the class remarks for how this is used to create
        /// a connection.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="dbCompiledModel"></param>
        public UnitOfWorkDbContextAsync(string nameOrConnectionString, DbCompiledModel dbCompiledModel)
            : base(nameOrConnectionString, dbCompiledModel)
        {

        }

        /// <summary>
        /// Constructs a new context instance around an existing ObjectContext.  An existing
        /// ObjectContext to wrap with the new context.  If set to true the ObjectContext
        /// is disposed when the DbContext is disposed, otherwise the caller must dispose
        /// the connection.
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="dbContextOwnsObjectContext"></param>
        public UnitOfWorkDbContextAsync(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Saves the Unit of Work context state
        /// </summary>
        public virtual Task SaveAsync()
        {
            return SaveChangesAsync();
        }

        #endregion

    }
}
