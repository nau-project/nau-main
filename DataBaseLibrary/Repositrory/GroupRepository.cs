using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;

namespace DataBaseLibrary.Repositrory
{
    public class GroupRepository: EntityRepository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context) : base(context)
        {
        }
    }
}
