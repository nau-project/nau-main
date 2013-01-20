using System;
using System.Collections.Generic;

namespace DataBaseLibrary.Entities
{
    public class Schedule
    {
        #region Propperties

        public Guid Id { set; get; }

        public virtual List<Item> Items { get; set; }
        
        #endregion
    }
}
