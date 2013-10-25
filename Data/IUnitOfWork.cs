using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Takenet.Library.Data
{
    /// <summary>
    /// Defines a common interface for data context objects
    /// which works with Unit of Work Pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save the context data
        /// </summary>
        void Save();
    }
}
