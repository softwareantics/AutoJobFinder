// <copyright file="HAPWebScraper.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoJobFinder.Scraping.HAP.Invoking;
    using HtmlAgilityPack;

    /// <summary>
    ///     Provides a HTML Agility Pack implementation of an <see cref="IWebScraper"/>.
    /// </summary>
    /// <seealso cref="AutoJobFinder.Scraping.IWebScraper"/>
    public class HAPWebScraper : IWebScraper
    {
        /// <summary>
        ///     The HTML document invoker.
        /// </summary>
        private readonly IHtmlDocumentInvoker document;

        /// <summary>
        ///     The root node.
        /// </summary>
        private IWebNode rootNode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HAPWebScraper"/> class.
        /// </summary>
        /// <param name="document">
        ///     Specifies the HTML Document Invoker to use with this <see cref="HAPWebScraper"/>.
        /// </param>
        /// <param name="html">
        ///     Specifies the HTML code to use with this <see cref="HAPWebScraper"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="document"/> or <paramref name="html"/> parameters are null.
        /// </exception>
        public HAPWebScraper(IHtmlDocumentInvoker document, string html)
        {
            this.document = document ?? throw new ArgumentNullException(nameof(document));

            if (string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentNullException(nameof(html));
            }

            this.document.LoadHtml(html);
            this.RootNode = new HAPWebNode(this.document.DocumentNode);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HAPWebScraper"/> class.
        /// </summary>
        /// <param name="html">
        ///     Specifies the HTML code to use with this <see cref="HAPWebScraper"/>.
        /// </param>
        [ExcludeFromCodeCoverage]
        public HAPWebScraper(string html)
            : this(new HtmlDocumentInvoker(new HtmlDocument()), html)
        {
        }

        /// <summary>
        ///     Gets the root node of this <see cref="IWebScraper"/>.
        /// </summary>
        /// <value>
        ///     The root node of this <see cref="IWebScraper"/>.
        /// </value>
        public IWebNode RootNode
        {
            get { return this.rootNode; }
            internal set { this.rootNode = value; }
        }
    }
}