using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class SectionsResponse
    {
        [JsonProperty("parse")]
        public SectionsParse Parse { get; set; }
    }
}
