using InfraEdge.API.InfraEdge.API.Data;
using InfraEdge.API.InfraEdge.API.Data.WikiApiClient;
using InfraEdge.API.InfraEdge.API.Logic;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var wikiLogic = new WikiApiLogic();
        foreach (var pair in wikiLogic.GetAllSpecialWordsOccurrences().GetAwaiter().GetResult())
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}