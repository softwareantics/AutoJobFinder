// <copyright file="HttpClientInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Sourcing.HttpClient.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Client = System.Net.Http.HttpClient;

    [ExcludeFromCodeCoverage]
    public class HttpClientInvoker : IHttpClientInvoker
    {
        private readonly Client client;

        public HttpClientInvoker(Client client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<string> GetStringAsync(string requestUri)
        {
            return this.client.GetStringAsync(requestUri);
        }
    }
}

#pragma warning restore SA1600 // Elements should be documented