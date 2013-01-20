using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Repositrory;

namespace DataBaseLibrary
{
    public interface IRepositories
    {

        ITeacherRepository TeacherRepository { get; }
        IScheduleRepository ScheduleRepository { get; }
        IStudentRepository StudentRepository { get; }
        IGroupRepository GroupRepository { get; }
        IItemRepository ItemRepository { get; }
        int Commit();
        void Initialize();
    }
}
