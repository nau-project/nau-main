using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseLibrary.Entities
{
    public class Group
    {
        #region Properties
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }

        public virtual Schedule Schedule1 { get; set; }
        public virtual Schedule Schedule2 { get; set; } 

        #endregion
    }
}
