using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DataBaseLibrary;
using NauMain.App.Json;
using NauMain.Models.Admin;
using DBLE = DataBaseLibrary.Entities;
using DataBaseLibrary.Manager;

namespace NauMain.Controllers
{
    public class GroupsController : Controller
    {
        //
        // GET: /Groups/
        
        public ActionResult Index(Guid? id)
        {
            IRepositories repositories =  new RepositoryFactory();
            var groups = repositories.GroupRepository.GetAll();
            var groupsModel = new List<Group>();

            groups.ForEach(gr => groupsModel.Add(new Group(gr)));
            return View("Groups", new DataContainer<List<Group>>(groupsModel, id));
        }
        
        [HttpPost]
        public ActionResult Index(string groupName)
        {
            IRepositories repositories = new RepositoryFactory();
            DBLE.Group gGroup = new DBLE.Group
                {
                    Id = Guid.NewGuid(),
                    Name = groupName,
                    Students = new List<DBLE.Student>()
                };
            repositories.GroupRepository.Insert(gGroup);
            repositories.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Schedule(Guid id)
        {
            IRepositories repositories = new RepositoryFactory();
            var schedules = new ScheduleManager(repositories).GetGroupSchedule(id);

            return View(new DataContainer<List<DBLE.Schedule>>(schedules, id));
        }

        public ActionResult Students(Guid id)
        {
            IRepositories repositories = new RepositoryFactory();

            var students = new List<Student>(); 
            
            (new GroupManager(repositories).GetStudents(id)).ForEach(st => students.Add(new Student(st)));
            repositories.Commit();

            return View(new DataContainer<List<Student>>(students, id));
        }

        [HttpGet]
        public ActionResult EditStudent(Guid id) //student Id
        {
            IRepositories repositories = new RepositoryFactory();
            DBLE.Student studentEntity = repositories.StudentRepository.GetById((Guid) id);
            Student student = new Student(studentEntity);
            
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student model)//student Id
        {
            IRepositories repositories = new RepositoryFactory();
            DBLE.Student student = StudentConverter(model);
            student.Id = model.Id;
            repositories.StudentRepository.Update(student);

            repositories.Commit();

            return RedirectToAction("Students", new { id = model.GroupId });
        }

        [HttpGet]
        public ActionResult AddStudent(Guid id)//groupId
        {
            return View("EditStudent", new Student{GroupId = id});
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            IRepositories repositories = new RepositoryFactory();
            DBLE.Student student = StudentConverter(model);

            student.Id = Guid.NewGuid();
            new GroupManager(repositories).AddStudent(model.GroupId, student);
            repositories.Commit();

            return RedirectToAction("Students", new { id = model.GroupId });
        }

        public ActionResult DeleteStudent(Guid groupId, Guid studentId)//studentId
        {
            IRepositories repositories = new RepositoryFactory();
            new GroupManager(repositories).DeleteStudent(studentId);

            repositories.Commit();
            return RedirectToAction("Students", new { id = groupId });
        }

        [HttpGet]
        public ActionResult AddItem(Guid? scheduleId, int dayNumber, int subgroupNumber, int order, Guid groupId)
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
                scheduleManager.AddGroupSchedule(groupId, schedule, subgroupNumber);
                repositories.Commit();

                return View(new Item
                {
                    Id = Guid.NewGuid(),
                    ScheduleId = (Guid)schedule.Id,
                    DataId = groupId,
                    Order = order,
                    NumberOfDay = dayNumber
                });
            }
          
            return View(new Item
                {
                    Id = Guid.NewGuid(),
                    ScheduleId = (Guid)scheduleId,
                    DataId = groupId,
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
            return RedirectToAction("Schedule", new{id = model.DataId});
        }

        [HttpGet]
        public ActionResult EditItem(Guid itemId, Guid groupId)
        {
            IRepositories repositories = new RepositoryFactory();
            var item = repositories.ItemRepository.GetById(itemId);
            return View("AddItem", new Item
                {
                    AdditionalInformation = item.AdditionalInformation,
                    CourceName = item.CourceName,
                    Id = itemId,
                    ScheduleId = item.Id,
                    DataId = groupId,
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
            return RedirectToAction("Schedule", new {id = model.DataId});
        }

        [HttpPost]
        public ActionResult DeleteItem(Guid itemId, Guid dataId)
        {
            IRepositories repositories = new RepositoryFactory();
            repositories.ItemRepository.Delete(itemId);
            repositories.Commit();
            return RedirectToAction("Schedule", new { id = dataId });
        }
        
        private DBLE.Student StudentConverter(Student model)
        {
            return new DBLE.Student
            {
                Name = model.Name,
                Login = model.Login,
                Password = model.Password,
                PasswordChanged = false,
                SubgroupNumber = model.SubgroupNumber
            };
        }

        public ActionResult DeleteGroup(Guid id)
        {
            IRepositories repositories = new RepositoryFactory();
            repositories.GroupRepository.Delete(id);
            repositories.Commit();
            return RedirectToAction("Index");
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

