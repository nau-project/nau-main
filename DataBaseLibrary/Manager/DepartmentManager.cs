using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLibrary.Entities;

namespace DataBaseLibrary.Manager
{
    public class DepartmentManager
    {
       private IRepositories r;
 
       public DepartmentManager(IRepositories r)
       {
          this.r = r;
       }
      
       public List<Teacher> GetTeachers()
       {
           var teachers = r.TeacherRepository.GetAll();
           return teachers != null ? teachers.ToList() : new List<Teacher>();
       }

       public void UpdateTeachers(IEnumerable<Teacher> teachers)
       {
           r.TeacherRepository.Update(teachers);
       }

       public void AddTeacher(Teacher teacher)
       {
           r.TeacherRepository.Insert(teacher);
       }

       public void AddTeacher(List<Teacher> teacher)
       {
           r.TeacherRepository.Insert(teacher);
       }
    }
}
