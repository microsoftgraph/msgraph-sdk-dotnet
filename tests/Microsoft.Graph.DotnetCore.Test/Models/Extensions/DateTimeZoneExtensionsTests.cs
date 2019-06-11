using Microsoft.Graph.Extensions;
using System;
using Xunit;
using System.Globalization;
using System.Collections.Generic;

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

            Assert.Equal(expectedDateTimeOffset, actualDateTimeOffset);
        }

        [Fact]
        public void FromDateTime_Should_Convert_DateTime_To_DateTimeTimeZone()
        {
            DateTimeStyles dateTimeStyles = DateTimeStyles.RoundtripKind;
            var dateTime = DateTime.ParseExact("2019-01-25T06:37:39.8058788Z", DateTimeFormat, CultureInfo.InvariantCulture, dateTimeStyles);
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
            List<DateTimeTimeZone> dateTimeTimeZoneList = new List<DateTimeTimeZone>();
            DateTimeTimeZone dateTimeTimeZoneTestOne = new DateTimeTimeZone
            {
                TimeZone = "Eastern Standard Time",
                DateTime = "2019-06-03T14:00:00.0000000"
            };
            dateTimeTimeZoneList.Add(dateTimeTimeZoneTestOne);

            DateTimeTimeZone dateTimeTimeZoneTestTwo = new DateTimeTimeZone
            {
                TimeZone = "UTC",
                DateTime = "2019-01-25T06:37:39.8058788Z"
            };
            dateTimeTimeZoneList.Add(dateTimeTimeZoneTestTwo);

            DateTimeTimeZone dateTimeTimeZoneTestThree = new DateTimeTimeZone
            {
                TimeZone = "Mauritius Standard Time",
                DateTime = "2019-06-03T22:00:00.0000000"
            };
            dateTimeTimeZoneList.Add(dateTimeTimeZoneTestThree);
            
            foreach (var dateTimeTimeZone in dateTimeTimeZoneList)
            {
                DateTime dateTime = GetDateTimeFromDateTimeTimeZone(dateTimeTimeZone);
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);

                TimeSpan offset = timeZoneInfo.GetUtcOffset(dateTime);
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);

                var expectedDateTimeOffset = new DateTimeOffset(dateTime, offset);
                expectedDateTimeOffset = TimeZoneInfo.ConvertTime(expectedDateTimeOffset, timeZoneInfo);
                var actualDateTimeTimeZone = DateTimeTimeZone.FromDateTimeOffset(expectedDateTimeOffset, dateTimeTimeZone.TimeZone);

                Assert.Equal(expectedDateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture), actualDateTimeTimeZone.DateTime);
                Assert.Equal(timeZoneInfo.Id, actualDateTimeTimeZone.TimeZone);
            }
        }

        private DateTime GetDateTimeFromDateTimeTimeZone(DateTimeTimeZone dateTimeTimeZone)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeFormat, CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}