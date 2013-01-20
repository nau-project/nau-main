#region Usages

using System;
using System.Collections.Generic;
using System.Data.Entity;

#endregion

namespace DataBaseLibrary
{
    /// <inheritdoc cref = 'IDalInitializer' />
    public class DalInitializer : DropCreateDatabaseAlways<DataContext>, IDalInitializer
    {
        #region IDalInitializer Members

        /// <inheritdoc />
        public virtual void Initialize()
        {
            Database.SetInitializer(this);
        }

        #endregion

        /// <inheritdoc />
        protected override void Seed(DataContext context)
        {
           
        }
    }
}