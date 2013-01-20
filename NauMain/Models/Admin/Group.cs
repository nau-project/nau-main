using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLE = DataBaseLibrary.Entities;

namespace NauMain.Models.Admin
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Group(DBLE.Group group)
        {
            Id = group.Id;
            Name = group.Name;
        }
    }
   public class DataContainer<TCData> where TCData:class 
   {
       public TCData Data { get; set; }
       public Guid? DataId { get; set; }

       public DataContainer()
       {}

       public DataContainer(TCData data, Guid? id = null)
       {
           DataId = id;
           Data = data;
       }
   }
}