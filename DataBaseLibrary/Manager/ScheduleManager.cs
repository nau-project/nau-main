using System;
using System.Collections.Generic;
using DataBaseLibrary;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositrory;

namespace DataBaseLibrary.Manager
{
    public class ScheduleManager
    {
        private IRepositories r;

        public ScheduleManager(IRepositories r)
        {
            this.r = r;
        }

        public Schedule GetTeacherSchedule(Guid teacherId)
        {
            var schedule = r.TeacherRepository.GetById(teacherId).Schedule;
            return schedule;
        }

        public void AddTeacherSchedule(Schedule schedule, Guid teacherId)
        {
            r.TeacherRepository.GetById(teacherId).Schedule = schedule;           
            r.ScheduleRepository.Insert(schedule);
        }

        public List<Schedule> GetGroupSchedule(Guid groupId)
        {
            var schedules = new List<Schedule>();
            schedules.Add(r.GroupRepository.GetById(groupId).Schedule1);
            schedules.Add(r.GroupRepository.GetById(groupId).Schedule2);
            return schedules;
        }

        public void AddGroupSchedule(Guid groupId, Schedule schedule, int subGroupNumber)
        {
            switch (subGroupNumber)
            {
                case 1: { r.GroupRepository.GetById(groupId).Schedule1 = schedule; break;}
                case 2: { r.GroupRepository.GetById(groupId).Schedule2 = schedule; break;}
                default:
                    {
                        throw new InvalidOperationException("Subgroup number mast be 1 or 2"); 
                    }
            }
        }

        public void AddItem(Guid scheduleId, Item item)
        {
            r.ScheduleRepository.GetById(scheduleId).Items.Add(item);
        }
    }
}
