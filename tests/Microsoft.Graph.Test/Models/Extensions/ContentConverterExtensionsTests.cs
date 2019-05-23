using Microsoft.Graph.Extensions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Graph.DotnetCore.Core.Test.Extensions
{
    [TestClass]
    public class ContentConverterExtensionsTests
    {
        [TestMethod]
        public void ToDateTime_Should_Convert_DateTimeTimeZone_To_DateTime()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var expectedDateTime = DateTime.Parse(dateTimeTimeZone.DateTime);
            Assert.AreEqual(expectedDateTime, dateTimeTimeZone.ToDateTime());
        }

        [TestMethod]
        public void ToDateTimeOffset_Should_Convert_DateTimeTimeZone_To_DateTimeOffset()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var expectedDateTimeOffset = DateTimeOffset.Parse(dateTimeTimeZone.DateTime).UtcDateTime;
            Assert.AreEqual(expectedDateTimeOffset, dateTimeTimeZone.ToDateTimeOffset());
        }
    }
}
