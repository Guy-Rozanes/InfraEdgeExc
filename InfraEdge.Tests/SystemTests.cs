using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using InfraEdge.API.InfraEdge.API.Logic;
using InfraEdge.UI.InfraEdge.UI.Buisness.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InfraEdge.Tests
{

    public class SystemTest
    {
        private WikiApiLogic wikiApiClient;
        private IWebDriver _webDriver;
        private WikiPage _wikiPage;

        [SetUp]
        public void SetUp()
        {
            // pre-condition: create a wiki client and driver
            wikiApiClient = new WikiApiLogic();
            _webDriver = new ChromeDriver();
            _wikiPage = new WikiPage(_webDriver);
        }

        [TearDown]
        public void TearDown()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
                _webDriver.Dispose();
            }
        }

        /*
         * Test that both resources are the same
         */
        [Test]
        public void DataVerfication()
        {
            var apiSpecialWords = wikiApiClient.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult();
            var uiSpecialWords = _wikiPage.GetNumberOfOccurrencesEachWord();
            CollectionAssert.AreEquivalent(apiSpecialWords, uiSpecialWords);
        }
    }
}