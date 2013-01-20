using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;

namespace DataBaseLibrary.Repositrory
{
    class ScheduleRepository: EntityRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DataContext context) : base(context)
        {
        }
    }
}
