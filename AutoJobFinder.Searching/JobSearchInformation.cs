// <copyright file="JobSearchInformation.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Searching
{
    using System;

    /// <summary>
    ///     Provides a class that represents information required by a job search engine.
    /// </summary>
    public class JobSearchInformation
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JobSearchInformation"/> class.
        /// </summary>
        /// <param name="title">
        ///     Specifies the title of the job.
        /// </param>
        /// <param name="location">
        ///     Specifies the location of the job (this can be country, town, city, post code, etc).
        /// </param>
        /// <param name="count">
        ///     Specifies the amount of jobs you wish to search for.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="title"/> or <paramref name="location"/> parameter is null.
        /// </exception>
        public JobSearchInformation(string title, string location)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            this.Title = title;
            this.Location = location;
        }

        /// <summary>
        ///     Gets the location of the job to search for.
        /// </summary>
        /// <value>
        ///     The location of the job to search for.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        ///     Gets the title of the job to search for.
        /// </summary>
        /// <value>
        ///     The title of the job to search for.
        /// </value>
        public string Title { get; set; }
    }
}