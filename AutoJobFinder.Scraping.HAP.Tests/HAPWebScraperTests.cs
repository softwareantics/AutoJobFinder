// <copyright file="HAPWebScraperTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP.Tests
{
    using System;
    using AutoJobFinder.Scraping.HAP.Invoking;
    using Moq;
    using NUnit.Framework;

    public class HAPWebScraperTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Document_Parameter_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new HAPWebScraper(null, "test"));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Html_Parameter_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new HAPWebScraper(new Mock<IHtmlDocumentInvoker>().Object, null));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Html_Parameter_Is_Empty()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new HAPWebScraper(new Mock<IHtmlDocumentInvoker>().Object, string.Empty));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Html_Parameter_Is_Whitespace()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new HAPWebScraper(new Mock<IHtmlDocumentInvoker>().Object, "\t\n\r"));
        }

        [Test]
        public void Constructor_Test_Should_Invoke_HtmlDocument_LoadHtml_Method()
        {
            // Arrange
            var htmlDocument = new Mock<IHtmlDocumentInvoker>();
            var node = new Mock<IHtmlNodeInvoker>();

            htmlDocument.SetupGet(i => i.DocumentNode).Returns(node.Object);

            // Act
            var webScraper = new HAPWebScraper(htmlDocument.Object, "test");

            // Assert
            htmlDocument.Verify(i => i.LoadHtml("test"));
        }

        [Test]
        public void RootNode_Test_Should_Not_Return_Null()
        {
            // Arrange
            var htmlDocument = new Mock<IHtmlDocumentInvoker>();
            var node = new Mock<IHtmlNodeInvoker>();

            htmlDocument.SetupGet(i => i.DocumentNode).Returns(node.Object);

            var webScraper = new HAPWebScraper(htmlDocument.Object, "test");

            // Act
            var actual = webScraper.RootNode;

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void RootNode_Test_Should_Return_Invoke_DocumentNode_Property()
        {
            // Arrange
            var htmlDocument = new Mock<IHtmlDocumentInvoker>();
            var node = new Mock<IHtmlNodeInvoker>();

            htmlDocument.SetupGet(i => i.DocumentNode).Returns(node.Object);

            var webScraper = new HAPWebScraper(htmlDocument.Object, "test");

            // Act
            _ = webScraper.RootNode;

            // Assert
            htmlDocument.VerifyGet(i => i.DocumentNode);
        }
    }
}