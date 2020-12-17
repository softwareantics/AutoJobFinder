// <copyright file="IWebScraperFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping
{
    /// <summary>
    ///     Defines an interface that provides a method for creating an <see cref="IWebScraper"/>.
    /// </summary>
    public interface IWebScraperFactory
    {
        /// <summary>
        ///     Creates an <see cref="IWebScraper"/> that scrapes the specified <paramref
        ///     name="html"/> code.
        /// </summary>
        /// <param name="html">
        ///     Specifies the HTML code to scrape.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="IWebScraper"/>.
        /// </returns>
        IWebScraper CreateWebScraper(string html);
    }
}