using Microsoft.Graph.Extensions;
using System;
using Xunit;
using System.Globalization;

namespace Microsoft.Graph.DotnetCore.Test.Extensions
{
    public class DateTimeZoneExtensionsTests
    {
        [Fact]
        public void ToDateTime_Should_Convert_DateTimeTimeZone_To_DateTime()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var expectedDateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, @"yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture);
            Assert.Equal(expectedDateTime, dateTimeTimeZone.ToDateTime(@"yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void ToDateTimeOffset_Should_Convert_DateTimeTimeZone_To_DateTimeOffset()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var expectedDateTimeOffset = DateTimeOffset.ParseExact(dateTimeTimeZone.DateTime, "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture).UtcDateTime;
            Assert.Equal(expectedDateTimeOffset, dateTimeTimeZone.ToDateTimeOffset("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void FromDateTime_Should_Convert_DateTime_To_DateTimeTimeZone()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "",
                DateTime = ""
            };

            var expectedDateTime = DateTime.ParseExact("2019-01-25T06:37:39.8058788Z", "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture).ToUniversalTime();
            var actualDateTime = dateTimeTimeZone.FromDateTime(expectedDateTime, "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture);

            Assert.Equal(expectedDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture), actualDateTime.DateTime);
        }

        [Fact]
        public void FromDateTimeOffset_Should_Convert_DateTimeOffset_To_DateTimeTimeZone()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "",
                DateTime = ""
            };

            var expectedDateTimeOffset = DateTimeOffset.ParseExact("2019-01-25T06:37:39.8058788Z", "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture).ToUniversalTime();
            var actualDateTimeOffset = dateTimeTimeZone.FromDateTimeOffset(expectedDateTimeOffset, "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture);

            Assert.Equal(expectedDateTimeOffset.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture), actualDateTimeOffset.DateTime);
        }
    }
}
