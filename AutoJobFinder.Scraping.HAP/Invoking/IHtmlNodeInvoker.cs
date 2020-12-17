// <copyright file="IHtmlNodeInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Scraping.HAP.Invoking
{
    using System.Collections.Generic;

    public interface IHtmlNodeInvoker
    {
        string InnerText { get; }

        IEnumerable<IHtmlNodeInvoker> Descendants(string name);

        string GetAttributeValue(string name, string def);
    }
}

#pragma warning restore SA1600 // Elements should be documented