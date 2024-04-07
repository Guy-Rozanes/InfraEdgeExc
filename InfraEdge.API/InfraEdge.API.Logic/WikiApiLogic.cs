using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using InfraEdge.API.InfraEdge.API.Data.WikiApiClient.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string[] filterOut = { "edit", "doi", "10 1109 ms 2007 80", "S2CID", "30671391" };
            var wikiResponse = await _wikiApiClient.GetSectionContentAsync("Test_automation", "Test-driven development");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(wikiResponse.Parse.Text.RenderedHtml);
            var allWordsLinks = xmlDoc.SelectNodes("//a")!.Cast<XmlNode>()
                .Select(item => item.InnerText)
                .Select(item => Regex.Replace(item, @"\[.*?\]", ""))
                .Select(item => Regex.Replace(item, @"[\W]", " "))
                .Where(linkText => !filterOut.Contains(linkText) && linkText != "" && linkText != " " && linkText != null).ToList();

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
