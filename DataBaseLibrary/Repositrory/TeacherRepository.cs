using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;


namespace DataBaseLibrary.Repositrory
{
    public class TeacherRepository : DataBaseLibrary.Repositories.EntityRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DataContext context) : base(context)
        {
        }
    }
}
