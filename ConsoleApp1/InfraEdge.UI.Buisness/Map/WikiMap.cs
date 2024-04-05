using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEdge.UI.InfraEdge.UI.Buisness.Map
{
    public class WikiMap
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait initWait;

        public WikiMap(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Test_automation");
            initWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }


        public IWebElement TestDrivenDevelopmentLink => _webDriver.FindElement(By.LinkText("Test-driven development"));

        public IWebElement TestDrivenDevelopmentTextSection => _webDriver.FindElement(By.CssSelector("#mw-content-text > div.mw-content-ltr.mw-parser-output > p:nth-child(35)"));

        public IWebElement TestDrivenDevelopmentTitleSection => _webDriver.FindElement(By.Id("Test-driven_development"));

        public IList<IWebElement> TestDrivenDeploymentSpecialWords => TestDrivenDevelopmentTextSection.FindElements(By.TagName("a"));
    }
}



