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
        private IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            // pre-condition: create a wiki client and driver
            wikiApiClient = new WikiApiLogic();
            webDriver = new ChromeDriver();

        }

        [TearDown]
        public void TearDown()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver.Dispose();
            }
        }

        /*
         * Test that both resources are the same
         */
        [Test]
        public void DataVerfication()
        {
            var apiSpecialWords = wikiApiClient.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult();
            var uiSpecialWords = wikiApiClient.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult();
            CollectionAssert.AreEquivalent(apiSpecialWords, uiSpecialWords);
        }
    }
}