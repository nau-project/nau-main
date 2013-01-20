using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseLibrary.Entities
{
    public class Student: Member
    {
        public int SubgroupNumber { get; set; }
        public virtual Group Group { get; set; }
    }
}
