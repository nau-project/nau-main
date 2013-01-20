using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;

namespace DataBaseLibrary.Manager
{
    public class GroupManager
    {
        private IRepositories r;
        
        public GroupManager(IRepositories repositories)
        {
            r = repositories;  
        }

        public void AddGroup(Group group)
        {
            r.GroupRepository.Insert(group);
        }

        public void AddStudent(Guid grupId, Student student)
        {
            r.StudentRepository.Insert(student);
            r.GroupRepository.GetById(grupId).Students.Add(student);
        }

        public void AddStudents(Guid grupId,IEnumerable<Student> students)
        {
            if (students != null)
            {
                r.StudentRepository.Insert(students);
            
                foreach (var student in students)
                {
                    r.GroupRepository.GetById(grupId).Students.Add(student);  
                }
            }
        }
 
        public List<Student> GetStudents(Guid groupId)
        {
            return r.GroupRepository.GetById(groupId).Students;
        }

        public void DeleteStudent(Guid studentId)
        {
            r.StudentRepository.Delete(studentId);
        }
    }
}
