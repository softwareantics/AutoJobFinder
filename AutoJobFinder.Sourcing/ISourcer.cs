// <copyright file="ISourcer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Sourcing
{
    using System.Threading.Tasks;

    /// <summary>
    ///     Defines an interface that provides a method for retrieving source code.
    /// </summary>
    public interface ISourcer
    {
        /// <summary>
        ///     Gets the source code from the speciifed <paramref name="url"/>.
        /// </summary>
        /// <param name="url">
        ///     The URL (or location on disk) of the source code file.
        /// </param>
        /// <returns>
        ///     THe source code, as a <see cref="Task"/> object.
        /// </returns>
        Task<string> GetSource(string url);
    }
}