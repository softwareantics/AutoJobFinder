// <copyright file="HAPWebScraperFactoryTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP.Tests
{
    using System;
    using AutoJobFinder.Scraping.HAP.Invoking;
    using Moq;
    using NUnit.Framework;

    public class HAPWebScraperFactoryTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert.
            Assert.DoesNotThrow(() => new HAPWebScraperFactory(new Mock<IHtmlDocumentInvoker>().Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Document_Parameter_Is_NulL()
        {
            // Arrange, act and assert.
            Assert.Throws<ArgumentNullException>(() => new HAPWebScraperFactory(null));
        }

        [Test]
        public void CreateWebScraper_Test_Should_Return_New_WebScraper()
        {
            // Arrange
            var document = new Mock<IHtmlDocumentInvoker>();

            document.SetupGet(i => i.DocumentNode).Returns(new Mock<IHtmlNodeInvoker>().Object);

            var factory = new HAPWebScraperFactory(document.Object);

            // Act
            var actual = factory.CreateWebScraper("potato");

            // Assert
            Assert.NotNull(actual);
        }

        public void CreateWebScraper_Test_Should_Throw_ArgumentNullException_When_Parameter_Is_Empty()
        {
            // Arrange
            var document = new Mock<IHtmlDocumentInvoker>();
            var factory = new HAPWebScraperFactory(document.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => factory.CreateWebScraper(string.Empty));
        }

        public void CreateWebScraper_Test_Should_Throw_ArgumentNullException_When_Parameter_Is_Null()
        {
            // Arrange
            var document = new Mock<IHtmlDocumentInvoker>();
            var factory = new HAPWebScraperFactory(document.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => factory.CreateWebScraper(null));
        }

        public void CreateWebScraper_Test_Should_Throw_ArgumentNullException_When_Parameter_Is_WhiteSpace()
        {
            // Arrange
            var document = new Mock<IHtmlDocumentInvoker>();
            var factory = new HAPWebScraperFactory(document.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => factory.CreateWebScraper("\t\r\n"));
        }
    }
}