using InfraEdge.UI.InfraEdge.UI.Buisness.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InfraEdge.Tests
{

    public class UITests
    {
        public IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            // pre-condition: create a webDriver
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

        /*Test every word got its repeat amount
         * Go to wiki
         * extract link words
         * group by them
         */
        [Test]
        public void WordsExists()
        {
            var wikiPage = new WikiPage(webDriver);
            var words = wikiPage.GetNumberOfOccurrencesEachWord();
            foreach (var word in words)
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
            var wikiPage = new WikiPage(webDriver);
            var words = wikiPage.GetNumberOfOccurrencesEachWord();
            foreach (var word in words)
            {
                Assert.IsNotEmpty(word.Key);
            }
        }
    }
}