// <copyright file="JobSearcherBaseTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Searching.Tests
{
    using System;
    using System.Reflection;
    using AutoJobFinder.Scraping;
    using AutoJobFinder.Sourcing;
    using Moq;
    using NUnit.Framework;

    public class JobSearcherBaseTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Factory_Is_Null()
        {
            // Arrange
            IWebScraperFactory factory = null;
            ISourcer sourcer = new Mock<ISourcer>().Object;

            // Act
            try
            {
                _ = new Mock<JobSearcherBase>(factory, sourcer).Object;
            }
            catch (TargetInvocationException e)
            {
                // Assert
                if (e.InnerException.GetType() == typeof(ArgumentNullException))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Sourcer_Is_Null()
        {
            // Arrange
            IWebScraperFactory factory = new Mock<IWebScraperFactory>().Object;
            ISourcer sourcer = null;

            // Act
            try
            {
                _ = new Mock<JobSearcherBase>(factory, sourcer).Object;
            }
            catch (TargetInvocationException e)
            {
                // Assert
                if (e.InnerException.GetType() == typeof(ArgumentNullException))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}