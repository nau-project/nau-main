using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseLibrary.Entities
{
    public class Teacher:Member
    {
        #region Properties

        public string Possition { get; set; }

        public List<Group> Groups { get; set; }
        
        public virtual Schedule Schedule { get; set; }
        
        #endregion
    }
}
