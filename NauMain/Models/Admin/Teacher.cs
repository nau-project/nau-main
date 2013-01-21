using System;
using System.ComponentModel.DataAnnotations;
using DBLE = DataBaseLibrary.Entities;
using Newtonsoft.Json;

namespace NauMain.Models.Admin
{
    public class Teacher : Member
    {

        [Display(Name = "Посада")]
        public string Possition { set; get; }
        
        public Teacher(DBLE.Teacher teacher):base(member: teacher)
        {
            Possition = teacher.Possition; 
        }

        public Teacher()
        {}

        public DBLE.Teacher ConvertToEntity()
        {
            return new DBLE.Teacher
            {
                Id = (Guid) Id,
                Name = Name,
                Login = Login,
                Password = Password,
                Possition = Possition
            };
        }

    }
}