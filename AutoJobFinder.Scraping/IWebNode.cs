// <copyright file="IWebNode.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping
{
    using System.Collections.Generic;

    /// <summary>
    ///     Defines an interface that represents an internet node.
    /// </summary>
    public interface IWebNode
    {
        /// <summary>
        ///     Gets the inner text.
        /// </summary>
        /// <value>
        ///     The inner text.
        /// </value>
        string InnerText { get; }

        /// <summary>
        ///     Gets the attribute value, of the specified <paramref name="name"/> for this <see cref="IWebNode"/>.
        /// </summary>
        /// <param name="name">
        ///     Specifies the attribute name to search for within this <see cref="IWebNode"/>.
        /// </param>
        /// <returns>
        ///     The attribute value of the specified <paramref name="name"/> for this <see cref="IWebNode"/>.
        /// </returns>
        string GetAttributeValue(string name);

        /// <summary>
        ///     Gets the descendants of this <see cref="IWebNode"/> that contain the specified
        ///     <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        ///     Specifies the name to search for within this <see cref="IWebNode"/>.
        /// </param>
        /// <returns>
        ///     A read-only collection of <see cref="IWebNode"/>'s that contain the specified
        ///     <paramref name="name"/> within this <see cref="IWebNode"/>.
        /// </returns>
        IReadOnlyCollection<IWebNode> GetDescendants(string name);
    }
}