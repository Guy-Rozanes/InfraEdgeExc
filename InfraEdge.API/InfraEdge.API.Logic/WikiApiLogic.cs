using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InfraEdge.API.InfraEdge.API.Logic
{
    public class WikiApiLogic
    {
        private WikiApiClient _wikiApiClient;

        public WikiApiLogic(WikiApiClient? wikiApiClient = null)
        {
            _wikiApiClient = wikiApiClient ?? new WikiApiClient();
        }

        public async Task<Dictionary<string, int>> GetAllSpecialWordsOccurrences()
        {
            var wikiResponse = await _wikiApiClient.FetchSectionContent("Test-driven_development", 6);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(wikiResponse.Parse.Text.RenderedHtml);
            var allWordsLinks = xmlDoc.SelectNodes("//a")!.Cast<XmlNode>().Select(item => item.InnerText).ToList();
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();
            foreach (string word in allWordsLinks)
            {
                if (wordOccurrences.ContainsKey(word))
                    wordOccurrences[word]++;
                else
                    wordOccurrences[word] = 1;
            }
            return wordOccurrences;
        }
    }
}
