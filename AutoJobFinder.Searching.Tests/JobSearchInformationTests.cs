// <copyright file="JobSearchInformationTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Searching.Tests
{
    using System;
    using NUnit.Framework;

    public class JobSearchInformationTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Location_Parameter_Is_Empty()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation("test", string.Empty));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Location_Parameter_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation("test", null));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Location_Parameter_Is_WhiteSpace()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation("test", "\t\r\n"));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Title_Parameter_Is_Empty()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation(string.Empty, "test"));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Title_Parameter_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation(null, "test"));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Title_Parameter_Is_WhiteSpace()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new JobSearchInformation("\t\r\n", "test"));
        }

        [Test]
        public void Location_Test_Should_Return_America()
        {
            // Arrange
            const string Expected = "America";
            var info = new JobSearchInformation("test", Expected);

            // Act
            var actual = info.Location;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Location_Test_Should_Return_Australia()
        {
            // Arrange
            const string Expected = "Australia";
            var info = new JobSearchInformation("test", Expected);

            // Act
            var actual = info.Location;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Title_Test_Should_Return_Plumber()
        {
            // Arrange
            const string Expected = "Plumber";
            var info = new JobSearchInformation(Expected, "test");

            // Act
            var actual = info.Title;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Title_Test_Should_Return_Sound_Engineer()
        {
            // Arrange
            const string Expected = "Sound Engineer";
            var info = new JobSearchInformation(Expected, "test");

            // Act
            var actual = info.Title;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}