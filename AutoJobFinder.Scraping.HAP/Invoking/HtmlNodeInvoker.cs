// <copyright file="HtmlNodeInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Scraping.HAP.Invoking
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using HtmlAgilityPack;

    [ExcludeFromCodeCoverage]
    public class HtmlNodeInvoker : IHtmlNodeInvoker
    {
        private HtmlNode node;

        public HtmlNodeInvoker(HtmlNode node)
        {
            this.node = node ?? throw new ArgumentNullException(nameof(node));
        }

        public string InnerText
        {
            get { return this.node.InnerText; }
        }

        public IEnumerable<IHtmlNodeInvoker> Descendants(string name)
        {
            var result = new List<IHtmlNodeInvoker>();
            var descendants = this.node.Descendants(name);

            foreach (var descendant in descendants)
            {
                result.Add(new HtmlNodeInvoker(descendant));
            }

            return result;
        }

        public string GetAttributeValue(string name, string def)
        {
            return this.node.GetAttributeValue(name, def);
        }
    }
}

#pragma warning restore SA1600 // Elements should be documented