// <copyright file="HAPWebScraperFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoJobFinder.Scraping.HAP.Invoking;
    using HtmlAgilityPack;

    /// <summary>
    ///     Provides a HTML Agility Pack implementation of an <see cref="IWebScraperFactory"/>.
    /// </summary>
    /// <seealso cref="AutoJobFinder.Scraping.IWebScraperFactory"/>
    public class HAPWebScraperFactory : IWebScraperFactory
    {
        /// <summary>
        ///     The invoker.
        /// </summary>
        private readonly IHtmlDocumentInvoker invoker;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HAPWebScraperFactory"/> class.
        /// </summary>
        /// <param name="invoker">
        ///     Specifies the HTML document invoker used to create a new <see cref="HAPWebScraper"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="invoker"/> parameter is null.
        /// </exception>
        public HAPWebScraperFactory(IHtmlDocumentInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HAPWebScraperFactory"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public HAPWebScraperFactory()
            : this(new HtmlDocumentInvoker(new HtmlDocument()))
        {
        }

        /// <summary>
        ///     Creates a <see cref="HAPWebScraper"/> that scrapes the specified <paramref
        ///     name="html"/> code.
        /// </summary>
        /// <param name="html">
        ///     Specifies the HTML code to scrape.
        /// </param>
        /// <returns>
        ///     The newly created <see cref="HAPWebScraper"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     The speciifed <paramref name="html"/> parameter is null, empty or white space.
        /// </exception>
        public IWebScraper CreateWebScraper(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new HAPWebScraper(this.invoker, html);
        }
    }
}