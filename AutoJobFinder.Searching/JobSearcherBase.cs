// <copyright file="JobSearcherBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Searching
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoJobFinder.Scraping;
    using AutoJobFinder.Sourcing;

    /// <summary>
    ///     Provides an abstract representation of an <see cref="IJobSearcher"/>.
    /// </summary>
    /// <seealso cref="AutoJobFinder.Searching.IJobSearcher"/>
    public abstract class JobSearcherBase : IJobSearcher
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JobSearcherBase"/> class.
        /// </summary>
        /// <param name="factory">
        ///     Specifies the <paramref name="factory"/> used to create a <see cref="IWebScraper"/>
        ///     when calling the <see cref="Search(JobSearchInformation)"/> function.
        /// </param>
        /// <param name="sourcer">
        ///     Specifies the <paramref name="sourcer"/> used to retrieve the HTML (or even other) code.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="factory"/> or <paramref name="sourcer"/> parameter is null.
        /// </exception>
        protected JobSearcherBase(IWebScraperFactory factory, ISourcer sourcer)
        {
            this.Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.Sourcer = sourcer ?? throw new ArgumentNullException(nameof(sourcer));
        }

        /// <summary>
        ///     Gets the factory.
        /// </summary>
        /// <value>
        ///     The factory.
        /// </value>
        protected IWebScraperFactory Factory { get; }

        /// <summary>
        ///     Gets the sourcer.
        /// </summary>
        /// <value>
        ///     The sourcer.
        /// </value>
        protected ISourcer Sourcer { get; }

        /// <summary>
        ///     Searches for a job, containing the specified <paramref name="info"/>.
        /// </summary>
        /// <param name="info">
        ///     Specifies the <paramref name="info"/> relating to the job search.
        /// </param>
        /// <returns>
        ///     A read-only collection of job information(s) found.
        /// </returns>
        public abstract Task<IReadOnlyCollection<JobInformation>> Search(JobSearchInformation info);
    }
}