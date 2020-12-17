// <copyright file="HttpClientSourcer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Sourcing.HttpClient
{
    using System;
    using System.Threading.Tasks;
    using AutoJobFinder.Sourcing.HttpClient.Invoking;

    /// <summary>
    ///     Provides a <see cref="HttpClient"/> implementation of an <see cref="ISourcer"/>.
    /// </summary>
    /// <seealso cref="AutoJobFinder.Sourcing.ISourcer"/>
    public class HttpClientSourcer : ISourcer
    {
        /// <summary>
        ///     The client.
        /// </summary>
        private readonly IHttpClientInvoker client;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpClientSourcer"/> class.
        /// </summary>
        /// <param name="client">
        ///     Specifies the <paramref name="client"/> used to retrieve the source code.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="client"/> parameter is null.
        /// </exception>
        public HttpClientSourcer(IHttpClientInvoker client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        ///     Gets the source code from the speciifed <paramref name="url"/>.
        /// </summary>
        /// <param name="url">
        ///     The URL (or location on disk) of the source code file.
        /// </param>
        /// <returns>
        ///     THe source code, as a <see cref="Task"/> object.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="url"/> parameter is null, empty or white space.
        /// </exception>
        public async Task<string> GetSource(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            return await this.client.GetStringAsync(url);
        }
    }
}