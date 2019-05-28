using Microsoft.Graph.Extensions;
using System;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Extensions
{
    public class ContentConverterExtensionsTests
    {
        [Fact]
        public void ToDateTime_Should_Convert_DateTimeTimeZone_To_DateTime()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };  

            var expectedDateTime = DateTime.Parse(dateTimeTimeZone.DateTime);
            Assert.Equal(expectedDateTime, dateTimeTimeZone.ToDateTime());
        }

        [Fact]
        public void ToDateTimeOffset_Should_Convert_DateTimeTimeZone_To_DateTimeOffset()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var expectedDateTimeOffset = DateTimeOffset.Parse(dateTimeTimeZone.DateTime).UtcDateTime;
            Assert.Equal(expectedDateTimeOffset, dateTimeTimeZone.ToDateTimeOffset());
        }

        [Fact]
        public void FromDateTime_Should_Convert_DateTime_To_DateTimeTimeZone()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "",
                DateTime = ""
            };

            var expectedDateTime = DateTime.Parse("2019-01-25T06:37:39.8058788Z").ToUniversalTime();
            var actualDateTime = dateTimeTimeZone.FromDateTime(expectedDateTime);

            Assert.Equal(expectedDateTime.ToString(), actualDateTime.DateTime);
            Assert.Equal("UTC", actualDateTime.TimeZone);
        }

        [Fact]
        public void FromDateTimeOffset_Should_Convert_DateTimeOffset_To_DateTimeTimeZone()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "",
                DateTime = ""
            };

            var expectedDateTimeOffset = DateTimeOffset.Parse("2019-01-25T06:37:39.8058788Z");
            var actualDateTimeOffset = dateTimeTimeZone.FromDateTimeOffset(expectedDateTimeOffset);

            Assert.Equal(expectedDateTimeOffset.ToString(), actualDateTimeOffset.DateTime);
            Assert.Equal("UTC", actualDateTimeOffset.TimeZone);
        }
    }
}
