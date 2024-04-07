using Newtonsoft.Json;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class Section
    {
        [JsonProperty("line")]
        public string Line { get; set; }


        [JsonProperty("index")]
        public int Index { get; set; }
    }
}