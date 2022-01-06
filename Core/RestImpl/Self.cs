using Newtonsoft.Json;
using System;

namespace Aprimo.Opti.Core.Models.RestImpl
{
    public class Self
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }
}