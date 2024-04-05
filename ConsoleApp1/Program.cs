using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Linq;
using InfraEdge.UI.InfraEdge.UI.Buisness.Page;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        var wikiPage = new WikiPage(driver);
        foreach (var pair in wikiPage.GetNumberOfOccurrencesEachWord())
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        driver.Quit();
    }
}