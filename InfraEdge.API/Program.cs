using InfraEdge.API.InfraEdge.API.Data;
using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var a = new WikiApiClient();
        var bla = a.FetchSectionContent("Test-driven_development", 6).GetAwaiter().GetResult();
        Console.WriteLine(bla.Parse.Text.RenderedHtml);
    }
}