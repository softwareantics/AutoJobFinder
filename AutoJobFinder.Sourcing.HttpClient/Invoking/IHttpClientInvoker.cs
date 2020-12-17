// <copyright file="IHttpClientInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace AutoJobFinder.Sourcing.HttpClient.Invoking
{
    using System.Threading.Tasks;

    public interface IHttpClientInvoker
    {
        Task<string> GetStringAsync(string requestUri);
    }
}

#pragma warning restore SA1600 // Elements should be documented