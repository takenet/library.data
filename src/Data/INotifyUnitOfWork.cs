using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Takenet.Library.Data
{
    /// <summary>
    /// Able to notify changes on unit of work
    /// </summary>
    public interface INotifyUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Occours when the data is about to be saved
        /// </summary>
        event EventHandler OnSavingChanges;

        /// <summary>
        /// Occours when the data was successfully saved
        /// </summary>
        event EventHandler OnSavedChanges;
    }
}
