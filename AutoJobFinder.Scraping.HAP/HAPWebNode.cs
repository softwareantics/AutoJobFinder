// <copyright file="HAPWebNode.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP
{
    using System;
    using System.Collections.Generic;
    using AutoJobFinder.Scraping.HAP.Invoking;

    /// <summary>
    ///     Provides a HTML Agility Pack implementation of an <see cref="IWebNode"/>.
    /// </summary>
    /// <seealso cref="IWebNode"/>
    public class HAPWebNode : IWebNode
    {
        /// <summary>
        ///     The node invoker.
        /// </summary>
        private IHtmlNodeInvoker node;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HAPWebNode"/> class.
        /// </summary>
        /// <param name="node">
        ///     Specifies the node to invoke.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="node"/> parameter is null.
        /// </exception>
        public HAPWebNode(IHtmlNodeInvoker node)
        {
            this.node = node ?? throw new ArgumentNullException(nameof(node));
        }

        //// TODO: Unit test this.
        public string InnerText
        {
            get { return this.node.InnerText; }
        }

        /// <summary>
        ///     Gets the attribute value, of the specified <paramref name="name"/> for this <see cref="IWebNode"/>.
        /// </summary>
        /// <param name="name">
        ///     Specifies the attribute name to search for within this <see cref="IWebNode"/>.
        /// </param>
        /// <returns>
        ///     The attribute value of the specified <paramref name="name"/> for this <see cref="IWebNode"/>.
        /// </returns>
        public string GetAttributeValue(string name)
        {
            return this.node.GetAttributeValue(name, string.Empty);
        }

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
        public IReadOnlyCollection<IWebNode> GetDescendants(string name)
        {
            var result = new List<IWebNode>();
            var descendants = this.node.Descendants(name);

            foreach (var descendant in descendants)
            {
                result.Add(new HAPWebNode(descendant));
            }

            return result;
        }
    }
}