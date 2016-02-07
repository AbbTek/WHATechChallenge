using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WHA.Core.Domain;

namespace WHACodeChallenge.Controllers.Api.Messages
{
    public class ProcessFile
    {
        [JsonProperty("fileUrl")]
        public string FileURL { get; set; }
        [JsonProperty("betType")]
        public BetType BetType { get; set; }
    }
}