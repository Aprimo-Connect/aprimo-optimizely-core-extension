﻿using Newtonsoft.Json;
using System;

namespace Aprimo.Opti.Core.Models.RestImpl
{
    public partial class Definition
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("select-key")]
        public string SelectKey { get; set; }
    }
}