using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NauMain.App.Json
{
    [JsonObject]
    public class JsonTeacherList
    {
        [JsonProperty]
        public string AddedTeachers { get; set; }
        [JsonProperty] 
        public string EditedTeachers { get; set; } 
    }
}