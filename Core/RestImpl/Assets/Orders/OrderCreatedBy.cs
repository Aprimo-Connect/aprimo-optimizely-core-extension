using Newtonsoft.Json;
using System;

namespace Aprimo.Opti.Core.RestImpl.Orders
{
    public class OrderCreatedBy
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("select-key")]
        public string SelectKey { get; set; }
    }
}