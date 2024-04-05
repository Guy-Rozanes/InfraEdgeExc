using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class ParseData
    {
        [JsonProperty("text")]
        public required TextData Text { get; set; }
    }
}