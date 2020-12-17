// <copyright file="IHtmlDocumentInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Scraping.HAP.Invoking
{
    public interface IHtmlDocumentInvoker
    {
        IHtmlNodeInvoker DocumentNode { get; }

        void LoadHtml(string html);
    }
}

#pragma warning restore SA1600 // Elements should be documented