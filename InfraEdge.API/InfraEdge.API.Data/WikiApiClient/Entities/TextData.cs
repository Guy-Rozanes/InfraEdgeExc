﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class TextData
    {
        [JsonProperty("*")]
        public required string RenderedHtml { get; set; }
    }
}
