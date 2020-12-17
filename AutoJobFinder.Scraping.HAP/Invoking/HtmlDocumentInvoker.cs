// <copyright file="HtmlDocumentInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Scraping.HAP.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using HtmlAgilityPack;

    [ExcludeFromCodeCoverage]
    public class HtmlDocumentInvoker : IHtmlDocumentInvoker
    {
        private HtmlDocument document;

        public HtmlDocumentInvoker(HtmlDocument document)
        {
            this.document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public IHtmlNodeInvoker DocumentNode
        {
            get { return new HtmlNodeInvoker(this.document.DocumentNode); }
        }

        public void LoadHtml(string html)
        {
            this.document.LoadHtml(html);
        }
    }
}

#pragma warning restore SA1600 // Elements should be documented