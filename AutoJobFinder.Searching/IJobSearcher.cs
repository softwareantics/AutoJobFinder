// <copyright file="IJobSearcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Searching
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    ///     Defines an interface that provides a method to search for jobs.
    /// </summary>
    public interface IJobSearcher
    {
        /// <summary>
        ///     Searches for a job, containing the specified <paramref name="info"/>.
        /// </summary>
        /// <param name="info">
        ///     Specifies the <paramref name="info"/> relating to the job search.
        /// </param>
        /// <returns>
        ///     A read-only collection of job information(s) found.
        /// </returns>
        Task<IReadOnlyCollection<JobInformation>> Search(JobSearchInformation info);
    }
}