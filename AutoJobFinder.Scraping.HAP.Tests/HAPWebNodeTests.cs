// <copyright file="HAPWebNodeTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Scraping.HAP.Tests
{
    using System;
    using System.Collections.Generic;
    using AutoJobFinder.Scraping.HAP.Invoking;
    using Moq;
    using NUnit.Framework;

    public class HAPWebNodeTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException()
        {
            // Arrange, act and assert.
            Assert.Throws<ArgumentNullException>(() => new HAPWebNode(null));
        }

        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert.
            Assert.DoesNotThrow(() => new HAPWebNode(new Mock<IHtmlNodeInvoker>().Object));
        }

        [Test]
        public void GetAttributeValue_Test_Should_Invoke_HtmlNode_GetAttributeValue_Method()
        {
            // Arrange
            var htmlNode = new Mock<IHtmlNodeInvoker>();
            var webNode = new HAPWebNode(htmlNode.Object);

            // Act
            var actual = webNode.GetAttributeValue("test");

            // Assert
            htmlNode.Verify(i => i.GetAttributeValue("test", string.Empty));
        }

        [Test]
        public void GetDescendants_Test_Should_Invoke_HtmlNode_GetDescendants_Method()
        {
            // Arrange
            var htmlNode = new Mock<IHtmlNodeInvoker>();
            var webNode = new HAPWebNode(htmlNode.Object);

            // Act
            var actual = webNode.GetDescendants("test");

            // Assert
            htmlNode.Verify(i => i.Descendants("test"));
        }

        [Test]
        public void GetDescendants_Test_Should_Should_Not_Return_Null()
        {
            // Arrange
            var htmlNode = new Mock<IHtmlNodeInvoker>();

            htmlNode.Setup(i => i.Descendants(It.IsAny<string>())).Returns(new List<IHtmlNodeInvoker>());
            var webNode = new HAPWebNode(htmlNode.Object);

            // Act
            var actual = webNode.GetDescendants(string.Empty);

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void GetDescendants_Test_Should_Return_Five_WebNodes()
        {
            // Arrange
            var htmlNode = new Mock<IHtmlNodeInvoker>();

            var nodes = new List<IHtmlNodeInvoker>()
            {
                new Mock<IHtmlNodeInvoker>().Object,
                new Mock<IHtmlNodeInvoker>().Object,
                new Mock<IHtmlNodeInvoker>().Object,
                new Mock<IHtmlNodeInvoker>().Object,
                new Mock<IHtmlNodeInvoker>().Object,
            };

            htmlNode.Setup(i => i.Descendants(It.IsAny<string>())).Returns(nodes);
            var webNode = new HAPWebNode(htmlNode.Object);

            // Act
            var actual = webNode.GetDescendants(string.Empty);

            // Assert
            Assert.AreEqual(actual.Count, nodes.Count);
        }
    }
}