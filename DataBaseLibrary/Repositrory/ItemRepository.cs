using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;

namespace DataBaseLibrary.Repositrory
{
    public class ItemRepository: EntityRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        {
        }
    }
}
