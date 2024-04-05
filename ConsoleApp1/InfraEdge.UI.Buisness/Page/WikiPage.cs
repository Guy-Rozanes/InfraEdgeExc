using InfraEdge.UI.InfraEdge.UI.Buisness.Map;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfraEdge.UI.InfraEdge.UI.Buisness.Page
{
    public class WikiPage
    {
        private WikiMap wikiMap;
        public WikiPage(IWebDriver webDriver)
        {
            wikiMap = new WikiMap(webDriver);
        }

        private string GetTestDrivenDeploymentText()
        {
            return wikiMap.TestDrivenDevelopmentTextSection.Text;
        }

        private List<string> GetTestDrivenDeploymentCleanedText()
        {
            return wikiMap.TestDrivenDeploymentSpecialWords.Select(
                item => Regex.Replace(item.Text.ToLower(), @"\[.*?\]", ""))
                .Select(item => Regex.Replace(item, @"[\W]", " ")).Where(linkText => !string.IsNullOrEmpty(linkText)).ToList();

        }

        public Dictionary<string, int> GetNumberOfOccurrencesEachWord()
        {
            List<string> words = GetTestDrivenDeploymentCleanedText();
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();
            foreach (string word in words)
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
