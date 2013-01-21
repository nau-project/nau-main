using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NauMain.Models.Admin
{
     public class Student: Member
     {
         public Student(DataBaseLibrary.Entities.Student student) : base(student)
         {
             SubgroupNumber = student.SubgroupNumber;
             GroupId = student.Group.Id;
         }

         public Student()
         {
         }

         public Guid GroupId { get; set; }
         [Display(Name = "Номер підгрупи")]
         public int SubgroupNumber { get; set; }
      }
}
