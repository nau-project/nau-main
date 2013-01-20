using System;
using DBLE = DataBaseLibrary.Entities;
using Newtonsoft.Json;

namespace NauMain.Models.Admin
{
    public class Member
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Login { set; get; }

        public string Password { get; set; }

        public Member(DBLE.Member member)
        {
             Id = member.Id;
             Name = member.Name;
             Login = member.Login;
             Password = (member.PasswordChanged) ? "Changed" : member.Password;
        }

        public Member()
        {
            
        }
    }
}