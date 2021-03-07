namespace Temp
{
    using System;
    using System.Net.Http;
    using AutoJobFinder.Scraping.HAP;
    using AutoJobFinder.Searching;
    using AutoJobFinder.Searching.Seek;
    using AutoJobFinder.Sourcing.HttpClient;
    using AutoJobFinder.Sourcing.HttpClient.Invoking;

    internal static class Program
    {
        private static void Main()
        {
            var client = new HttpClientInvoker(new HttpClient());
            var sourcer = new HttpClientSourcer(client);

            var factory = new HAPWebScraperFactory();

            var jobSearcher = new SeekJobSearcher(factory, sourcer);
            var searchInfo = new JobSearchInformation("Sound Engineer", "Victoria");

            foreach (JobInformation result in jobSearcher.Search(searchInfo).Result)
            {
                Console.WriteLine(result.Title);
                Console.WriteLine(result.CompanyName);
                Console.WriteLine(result.URL);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}