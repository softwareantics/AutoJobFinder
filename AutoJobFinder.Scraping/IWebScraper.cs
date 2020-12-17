// <copyright file="IWebScraper.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping
{
    /// <summary>
    /// Defines an interface that represents an internet scraper.
    /// </summary>
    public interface IWebScraper
    {
        /// <summary>
        /// Gets the root node of this <see cref="IWebScraper"/>.
        /// </summary>
        /// <value>
        /// The root node of this <see cref="IWebScraper"/>.
        /// </value>
        IWebNode RootNode { get; }
    }
}