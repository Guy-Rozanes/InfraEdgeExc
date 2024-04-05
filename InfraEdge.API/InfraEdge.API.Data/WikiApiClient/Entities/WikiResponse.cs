using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class WikiResponse
    {
        [JsonProperty("parse")]
        public required ParseData Parse { get; set; }
    }
}
