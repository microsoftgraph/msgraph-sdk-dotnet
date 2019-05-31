using Microsoft.Graph.Extensions;
using System;
using Xunit;
using System.Globalization;

namespace Microsoft.Graph.DotnetCore.Test.Extensions
{
    public class DateTimeZoneExtensionsTests
    {
        internal const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffK";

        [Fact]
        public void ToDateTime_Should_Convert_DateTimeTimeZone_To_DateTime()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            var actualDateTime = dateTimeTimeZone.ToDateTime();
            var expectedDateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeFormat, CultureInfo.InvariantCulture);

            Assert.Equal(expectedDateTime, actualDateTime);
        }

        [Fact]
        public void ToDateTimeOffset_Should_Convert_DateTimeTimeZone_To_DateTimeOffset()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeFormat, CultureInfo.InvariantCulture);
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);          
            TimeSpan offset = timeZoneInfo.GetUtcOffset(dateTime);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            var expectedDateTimeOffset = new DateTimeOffset(dateTime, offset);
            var actualDateTimeOffset = dateTimeTimeZone.ToDateTimeOffset();

            Assert.True(expectedDateTimeOffset.Equals(actualDateTimeOffset));
        }

        [Fact]
        public void FromDateTime_Should_Convert_DateTime_To_DateTimeTimeZone()
        {
            var dateTime = DateTime.ParseExact("2019-01-25T06:37:39.8058788Z", DateTimeFormat, CultureInfo.InvariantCulture).ToUniversalTime();
            var expectedDateTime = dateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

            DateTimeTimeZone expectedDateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = expectedDateTime
            };

            var actualDateTimeTimeZone = DateTimeTimeZone.FromDateTime(dateTime, "UTC");

            Assert.Equal(expectedDateTimeTimeZone.DateTime, actualDateTimeTimeZone.DateTime);
            Assert.Equal(expectedDateTimeTimeZone.TimeZone, actualDateTimeTimeZone.TimeZone);
        }

        [Fact]
        public void FromDateTimeOffset_Should_Convert_DateTimeOffset_To_DateTimeTimeZone()
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };

            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeFormat, CultureInfo.InvariantCulture);

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);
            TimeSpan offset = timeZoneInfo.GetUtcOffset(dateTime);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            var expectedDateTimeOffset = new DateTimeOffset(dateTime, offset);
            expectedDateTimeOffset = TimeZoneInfo.ConvertTime(expectedDateTimeOffset, timeZoneInfo);
            var actualDateTimeTimeZone = DateTimeTimeZone.FromDateTimeOffset(expectedDateTimeOffset, dateTimeTimeZone.TimeZone);

            Assert.Equal(expectedDateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture), actualDateTimeTimeZone.DateTime);
        }
    }
}