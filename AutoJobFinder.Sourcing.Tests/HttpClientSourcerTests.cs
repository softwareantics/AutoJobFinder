// <copyright file="HttpClientSourcerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace AutoJobFinder.Sourcing.HttpClient.Tests
{
    using System;
    using System.Threading.Tasks;
    using AutoJobFinder.Sourcing.HttpClient.Invoking;
    using Moq;
    using NUnit.Framework;

    public class HttpClientSourcerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new HttpClientSourcer(new Mock<IHttpClientInvoker>().Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Client_Parameter_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new HttpClientSourcer(null));
        }

        [Test]
        public void GetSource_Test_Should_Return_Test()
        {
            // Arrange
            const string Expected = "test";
            var client = new Mock<IHttpClientInvoker>();

            client.Setup(i => i.GetStringAsync(It.IsAny<string>())).Returns(this.DelegateFunction());

            var sourcer = new HttpClientSourcer(client.Object);

            // Act
            var actual = sourcer.GetSource("potato");

            // Assert
            Assert.AreEqual(Expected, actual.Result);
        }

        [Test]
        public void GetSource_Test_Should_Throw_ArgumentNullException_When_Url_Parameter_Is_Empty()
        {
            // Arrange
            var client = new Mock<IHttpClientInvoker>().Object;
            var sourcer = new HttpClientSourcer(client);

            // Act and assert
            Assert.ThrowsAsync<ArgumentNullException>(() => sourcer.GetSource(string.Empty));
        }

        [Test]
        public void GetSource_Test_Should_Throw_ArgumentNullException_When_Url_Parameter_Is_Null()
        {
            // Arrange
            var client = new Mock<IHttpClientInvoker>().Object;
            var sourcer = new HttpClientSourcer(client);

            // Act and assert
            Assert.ThrowsAsync<ArgumentNullException>(() => sourcer.GetSource(null));
        }

        [Test]
        public void GetSource_Test_Should_Throw_ArgumentNullException_When_Url_Parameter_Is_WhiteSpace()
        {
            // Arrange
            var client = new Mock<IHttpClientInvoker>().Object;
            var sourcer = new HttpClientSourcer(client);

            // Act and assert
            Assert.ThrowsAsync<ArgumentNullException>(() => sourcer.GetSource("\t\r\n"));
        }

        private Task<string> DelegateFunction()
        {
            return Task.FromResult("test");
        }
    }
}