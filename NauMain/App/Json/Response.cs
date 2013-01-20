using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NauMain.App.Json
{
    [JsonObject]
    public class Response
    {
        [JsonObject]
        public class Error
        {
            [JsonProperty]
            public int ErrorCode { get; set; }
            [JsonProperty]
            public string Message { get; set; }
        }

        [JsonProperty]
        public Error ErrorObject { get; set;}
        [JsonProperty]
        public string Data { get; set; }
    }
}