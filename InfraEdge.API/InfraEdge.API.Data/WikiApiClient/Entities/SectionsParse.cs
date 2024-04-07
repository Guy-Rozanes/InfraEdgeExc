using Newtonsoft.Json;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities
{
    public class SectionsParse
    {
        [JsonProperty("sections")]
        public Section[] Sections { get; set; }
    }
}