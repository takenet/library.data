using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takenet.Library.Data
{
    /// <summary>
    /// Defines a common interface for data context objects
    /// which works with Unit of Work Pattern
    /// </summary>
    public interface IUnitOfWorkAsync : IDisposable
    {
        /// <summary>
        /// Save the context data
        /// </summary>
        Task SaveAsync();
    }
}
