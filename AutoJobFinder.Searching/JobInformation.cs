// <copyright file="JobInformation.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

//// TODO: Unit Test this once we've actually used it to scrape job information.

namespace AutoJobFinder.Searching
{
    /// <summary>
    ///     Represents a structure that defines information retrieved by a job search engine query.
    /// </summary>
    public struct JobInformation
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JobInformation"/> struct.
        /// </summary>
        /// <param name="companyName">
        ///     Specified the name of the company.
        /// </param>
        /// <param name="title">
        ///     Specifies the title of the job.
        /// </param>
        /// <param name="url">
        ///     Specifie the URL link that will take you to the next step towards applying for the
        ///     job (this is usually a page that contains more information such as wages, a larger
        ///     description, etc).
        /// </param>
        public JobInformation(string companyName, string title, string url)
        {
            this.CompanyName = companyName;
            this.Title = title;
            this.URL = url;
        }

        /// <summary>
        ///     Gets or sets the name of the company.
        /// </summary>
        /// <value>
        ///     The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        ///     Gets or sets the title of the ejob.
        /// </summary>
        /// <value>
        ///     The title of the job.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the URL link.
        /// </summary>
        /// <value>
        ///     The URL link.
        /// </value>
        public string URL { get; set; }
    }
}