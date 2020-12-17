// <copyright file="SeekJobSearcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

//// TODO: Unit Testing

namespace AutoJobFinder.Searching.Seek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoJobFinder.Scraping;
    using AutoJobFinder.Sourcing;

    /// <summary>
    ///     Provides a Seek implementation of the <see cref="JobSearcherBase"/> class.
    /// </summary>
    /// <seealso cref="AutoJobFinder.Searching.JobSearcherBase"/>
    public class SeekJobSearcher : JobSearcherBase
    {
        private const int ArticlesPerPage = 20;

        /// <summary>
        ///     The URL used to search for results.
        /// </summary>
        private const string BaseUrl = "https://www.seek.com.au";

        /// <summary>
        ///     Initializes a new instance of the <see cref="SeekJobSearcher"/> class.
        /// </summary>
        /// <param name="factory">
        ///     Specifies the <paramref name="factory"/> used to create a <see cref="IWebScraper"/>
        ///     when calling the <see cref="Search(JobSearchInformation)"/> function.
        /// </param>
        /// <param name="sourcer">
        ///     Specifies the <paramref name="sourcer"/> used to retrieve the HTML (or even other) code.
        /// </param>
        public SeekJobSearcher(IWebScraperFactory factory, ISourcer sourcer)
            : base(factory, sourcer)
        {
        }

        /// <summary>
        ///     Searches for a job, containing the specified <paramref name="info"/>.
        /// </summary>
        /// <param name="info">
        ///     Specifies the <paramref name="info"/> relating to the job search.
        /// </param>
        /// <returns>
        ///     A read-only collection of job information(s) found.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="info"/> parameter is null.
        /// </exception>
        public override async Task<IReadOnlyCollection<JobInformation>> Search(JobSearchInformation info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            string what = info.Title.Trim().Replace(" ", "-");
            string where = info.Location.Trim().Replace(" ", "-");

            string searchUrl = $"{BaseUrl}/{what}-jobs/in-{where}";
            string content = await this.Sourcer.GetSource(searchUrl);

            IWebScraper scraper = this.Factory.CreateWebScraper(content);
            var results = new List<JobInformation>();

            IWebNode resultsList = scraper.RootNode.GetDescendants("div")
                            .Where(i => i.GetAttributeValue("class")
                            .Contains("_3MPUOLE")).FirstOrDefault();

            if (resultsList == null)
            {
#if DEBUG
                Console.WriteLine("Failed to locate list items at: {0}", searchUrl);
#endif

                return null;
            }

            IEnumerable<IWebNode> articles = resultsList.GetDescendants("article")
                .Where(i => i.GetAttributeValue("data-job-id") != default);

            foreach (IWebNode article in articles)
            {
                IWebNode title = article.GetDescendants("h1").FirstOrDefault();
                IWebNode hyperlink = title.GetDescendants("a").FirstOrDefault();
                IWebNode company = article.GetDescendants("a").Where(i => i.GetAttributeValue("data-automation").Equals("jobCompany")).FirstOrDefault();

                var jobInfo = new JobInformation()
                {
                    Title = title?.InnerText,
                    CompanyName = company?.InnerText,
                    URL = $"{BaseUrl}{hyperlink?.GetAttributeValue("href")}",
                };

                if (jobInfo.Equals(default))
                {
                    continue;
                }

                results.Add(jobInfo);
            }

            return results;
        }
    }
}