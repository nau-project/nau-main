using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NauMain.Models.Admin
{
    public class Item
    {
        #region Propperties

        public Guid Id { get; set; }

        public Guid ScheduleId { get; set; }

        public Guid DataId { get; set; }

        public Guid EntityId { get; set; }

        public int Order { get; set; }

        public int NumberOfDay { get; set; }
        [Display(Name = "Назва предмету")]
        public string CourceName { get; set; }
        [Display(Name = "Додаткова інформація")]
        public string AdditionalInformation { get; set; }
        [Display(Name = "Аудиторія")]
        public string Audience { get; set; }

        #endregion

        
    }
}