using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public async Task<WikiResponse> FetchSectionContent(string pageTitle, string sectionTitle)
        {
            var url = $"{BASE_URL}?action=parse&page={pageTitle}&section={sectionTitle}&format=json";
            var response = await _httpClient.SendRequestAsync(CustomMethods.GET, url);
            return JsonConvert.DeserializeObject<WikiResponse>(response);
        }
        public async Task<WikiResponse> GetSectionContentAsync(string pageTitle, string sectionTitle)
        {
            using (HttpClient client = new HttpClient())
            {
                var sectionId = await GetSectionIdByName(pageTitle, sectionTitle);
                if (sectionId == -1)
                {
                    throw new Exception($"Cant found this section {sectionTitle}");
                }

                string apiUrl = $"{BASE_URL}?action=parse&page={pageTitle}&section={sectionId}&format=json";
                var response = await _httpClient.SendRequestAsync(CustomMethods.GET, apiUrl);
                return JsonConvert.DeserializeObject<WikiResponse>(response);

            }
        }

        private async Task<int> GetSectionIdByName(string pageTitle, string sectionTitle)
        {
            string parseUrl = $"{BASE_URL}?action=parse&page={pageTitle}&prop=sections&format=json";
            string sectionsResponse = await _httpClient.SendRequestAsync(CustomMethods.GET, parseUrl);
            var sections = JsonConvert.DeserializeObject<SectionsResponse>(sectionsResponse);
            int sectionId = -1;
            foreach (var section in sections.Parse.Sections)
            {
                if (section.Line == sectionTitle)
                {
                    sectionId = section.Index;
                }
            }
            return sectionId;
        }
    }
}
