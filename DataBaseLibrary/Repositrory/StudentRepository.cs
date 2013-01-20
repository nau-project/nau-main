using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;

namespace DataBaseLibrary.Repositrory
{
    public class StudentRepository: EntityRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context)
        {
        }
    }
}
