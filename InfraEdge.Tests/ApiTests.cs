using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using InfraEdge.API.InfraEdge.API.Logic;
using InfraEdge.UI.InfraEdge.UI.Buisness.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InfraEdge.Tests
{

    public class ApiTests
    {
        private WikiApiLogic wikiApiClient;

        [SetUp]
        public void SetUp()
        {
            // pre-condition: create a wiki client
            wikiApiClient = new WikiApiLogic();

        }

        [TearDown]
        public void TearDown()
        {

        }

        /*Test every word got its repeat amount
         * Go to wiki
         * extract link words
         * group by them
         */
        [Test]
        public void WordsExists()
        {
            var specialWords = wikiApiClient.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult();
            foreach (var word in specialWords)
            {
                Assert.IsTrue(word.Value >= 1);
            }
        }

        /* Test every word got its repeat amount
         * Go to wiki
         * extract link words
         * check every word is not empty (which means valid)
         */
        [Test]
        public void WordsAreNotEmpty()
        {
            var specialWords = wikiApiClient.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult();
            foreach (var word in specialWords)
            {
                Assert.IsNotEmpty(word.Key);
            }
        }
    }
}