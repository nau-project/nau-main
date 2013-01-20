using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositrory;

namespace DataBaseLibrary
{
    public class RepositoryFactory : IRepositories
    {
                #region Fields

        private DataContext context;

        private GroupRepository _groupRepository;
        private StudentRepository _studentRepository;
        private ScheduleRepository _scheduleRepository;
        private ItemRepository _itemRepository;
        private TeacherRepository _teacherRepository;

        #endregion

        #region Constructors

        public RepositoryFactory(DataContext context)
        {
            this.context = context;
        }

        public RepositoryFactory()
        {
            Initialize();
        }

        #endregion

        #region IUnitOfWork Members


        /// <inheritdoc />
        public IScheduleRepository ScheduleRepository
        {
            get { return _scheduleRepository ?? (_scheduleRepository = new ScheduleRepository(context)); }
        }


        public IStudentRepository StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = new StudentRepository(context)); }
        }

        public IGroupRepository GroupRepository
        {
            get { return _groupRepository ?? (_groupRepository = new GroupRepository(context)); }
        }

        public IItemRepository ItemRepository
        {
            get { return _itemRepository ?? (_itemRepository = new ItemRepository(context)); }
        }

        public ITeacherRepository TeacherRepository
        {
            get { return _teacherRepository ?? (_teacherRepository = new TeacherRepository(context)); }
        }

        /// <inheritdoc />
        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Initialize()
        {
            if (context != null)
            {
                throw new InvalidOperationException("Unit of work is already initialized.");
            }

            context = new DataContext();
        }

        #endregion
    }
}
