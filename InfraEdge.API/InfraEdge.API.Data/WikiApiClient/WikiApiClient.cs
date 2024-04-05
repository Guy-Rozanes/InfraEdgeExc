using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraEdge.API.Common;
using InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities;
using Newtonsoft.Json;

namespace InfraEdge.API.InfraEdge.API.Data.WikiApiClient
{
    public class WikiApiClient
    {
        private HttpClientWrapper _httpClient;
        private const string BASE_URL = "https://en.wikipedia.org/w/api.php";

        public WikiApiClient()
        {
            _httpClient = new HttpClientWrapper();
        }

        public async Task<WikiResponse> FetchSectionContent(string pageTitle, int sectionTitle)
        {
            var url = $"{BASE_URL}/?action=parse&page={pageTitle}&section={sectionTitle}&prop=text&format=json";
            var response = await _httpClient.SendRequestAsync(CustomMethods.GET, url);
            return JsonConvert.DeserializeObject<WikiResponse>(response);
        }

        
    }
}
