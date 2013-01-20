using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DataBaseLibrary;
using DBLE = DataBaseLibrary.Entities;
using DataBaseLibrary.Manager;
using NauMain.App.Json;
using NauMain.Models.Admin;

namespace NauMain.Controllers
{
    public class DepartmentAdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(Guid id)
        {
            IRepositories r = new RepositoryFactory();

            //Here chek Access rights
            List<DBLE.Teacher> teachers = new DepartmentManager(r).GetTeachers();
            List<Teacher> json = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                json.Add(new Teacher(teacher));
            }

            return View(json);
        }

        [HttpGet]
        public ActionResult AddTeacher()
        {
            
            return  View(new Teacher
                {
                    Id = Guid.NewGuid()
                });
        }

        [HttpPost]
        public ActionResult AddTeacher(Teacher model)
        {
            IRepositories repositories = new RepositoryFactory();
            repositories.TeacherRepository.Insert(Convert(model));
            repositories.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTeacher(Guid id)
        {
            IRepositories repositories = new RepositoryFactory();
            return View("AddTeacher", new Teacher(repositories.TeacherRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult EditTeacher(Teacher model)
        {
            IRepositories repositories = new RepositoryFactory();
            repositories.TeacherRepository.Update(Convert(model));
            repositories.Commit();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTeacher(Guid teacherId)//studentId
        {
            IRepositories repositories = new RepositoryFactory();
            new GroupManager(repositories).DeleteStudent(teacherId);

            repositories.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Schedule(Guid id)
        {
            IRepositories r = new RepositoryFactory();
            return View(new DataContainer<DBLE.Schedule>
                {
                    DataId = id,
                    Data = r.TeacherRepository.GetById(id).Schedule
                });
        }

        [HttpGet]
        public ActionResult AddItem(Guid? scheduleId, int dayNumber,  int order, Guid teacherId)
        {
            var repositories = new RepositoryFactory();
            var scheduleManager = new ScheduleManager(repositories);
            if (scheduleId == null)
            {
                var schedule = new DBLE.Schedule
                {
                    Id = Guid.NewGuid(),
                    Items = new List<DBLE.Item>()
                };
                scheduleManager.AddTeacherSchedule(schedule, teacherId);
                repositories.Commit();

                return View(new Item
                {
                    Id = Guid.NewGuid(),
                    ScheduleId = schedule.Id,
                    DataId = teacherId,
                    Order = order,
                    NumberOfDay = dayNumber
                });
            }

            return View(new Item
            {
                Id = Guid.NewGuid(),
                ScheduleId = (Guid)scheduleId,
                DataId = teacherId,
                Order = order,
                NumberOfDay = dayNumber

            });
        }

        [HttpPost]
        public ActionResult AddItem(Item model)
        {
            IRepositories repositories = new RepositoryFactory();
            new ScheduleManager(repositories).AddItem(model.ScheduleId, ItemConvertor(model));
            repositories.Commit();
            return RedirectToAction("Schedule", new { id = model.DataId });
        }

        [HttpGet]
        public ActionResult EditItem(Guid itemId, Guid teacherId)
        {
            IRepositories repositories = new RepositoryFactory();
            var item = repositories.ItemRepository.GetById(itemId);
            return View("AddItem", new Item
            {
                AdditionalInformation = item.AdditionalInformation,
                CourceName = item.CourceName,
                Id = itemId,
                ScheduleId = item.Id,
                DataId = teacherId,
                Order = item.Order,
                NumberOfDay = item.NumberOfDay,
                Audience = item.Audience,
                EntityId = item.EntityId
            });
        }

        [HttpPost]
        public ActionResult EditItem(Item model)
        {
            IRepositories repositories = new RepositoryFactory();
            DBLE.Item item = ItemConvertor(model);
            item.Id = model.Id;
            repositories.ItemRepository.Update(item);
            repositories.Commit();
            return RedirectToAction("Schedule", new { id = model.DataId });
        }

        [HttpPost]
        public ActionResult DeleteItem(Guid itemId, Guid dataId)
        {
            IRepositories repositories = new RepositoryFactory();
            repositories.ItemRepository.Delete(itemId);
            repositories.Commit();
            return RedirectToAction("Schedule", new {id = dataId});
        }

        private DBLE.Teacher Convert(Teacher teacher)
        {
            return new DBLE.Teacher()
                {
                    Id = teacher.Id,
                    Login = teacher.Login,
                    Possition = teacher.Possition,
                    Name = teacher.Name,
                    Password = teacher.Password,
                    PasswordChanged = false,
                    Groups = new List<DBLE.Group>()
                };
        }

        private DBLE.Item ItemConvertor(Item item)
        {
            return new DBLE.Item
            {
                Id = item.Id,
                AdditionalInformation = item.AdditionalInformation,
                Audience = item.Audience,
                CourceName = item.CourceName,
                NumberOfDay = item.NumberOfDay,
                Order = item.Order
            };
        }
    }
}