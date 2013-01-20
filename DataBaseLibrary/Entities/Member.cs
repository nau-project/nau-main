using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseLibrary.Entities
{
    public abstract class Member
    {
        #region Properties
        
        public Guid Id { set; get; }
        
        public string Name { set; get; }

        public string Login { set; get; }

        public string Password { get; set; }

        public bool PasswordChanged { get; set; }

        #endregion
    }
}
