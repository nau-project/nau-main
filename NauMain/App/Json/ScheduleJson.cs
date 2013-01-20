using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBaseLibrary;
using DataBaseLibrary.Entities;
using Newtonsoft.Json;

namespace NauMain.App.Json
{
   [JsonObject]
   public class DayOfWeek
   {
       [JsonProperty]
       public  List<Item> Items { get; set; }
   }

   [JsonObject]
   public class ScheduleJson
   {
       [JsonProperty]
       public List<DayOfWeek> Days { get; set; } 

       public ScheduleJson(List<Item> items)
       {
           Days = new List<DayOfWeek>();
           for(int i = 0; i < 14; i++)
           {
               Days.Add(new DayOfWeek(){Items = items.Where(item => item.NumberOfDay == i).OrderBy(it => it.Order).ToList()});
           } 
       } 
    }
}