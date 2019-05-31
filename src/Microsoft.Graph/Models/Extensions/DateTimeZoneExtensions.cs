// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.Graph.Extensions
{
    /// <summary>
    /// Implements DateTimeTimeZone Extensions
    /// </summary>

    public static class DateTimeTimeZoneExtensions
    {
        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTime
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeTimeZone dateTimeTimeZone)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeTimeZone.DateTimeFormat, CultureInfo.InvariantCulture);

            // Now we need to determine which DateTimeKind to set based on the time zone specified in the input object.

            TimeZoneInfo timeZoneInfo = DateTimeTimeZone.GetTimeZoneInfo(dateTimeTimeZone.TimeZone);

            DateTimeKind kind;
            if (timeZoneInfo.Id == TimeZoneInfo.Utc.Id)
            {
                kind = DateTimeKind.Utc;
            }
            else if (timeZoneInfo.Id == TimeZoneInfo.Local.Id)
            {
                kind = DateTimeKind.Local;
            }
            else
            {
                kind = DateTimeKind.Unspecified;
            }

            return DateTime.SpecifyKind(dateTime, kind);
        }

        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTimeOffset
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTimeTimeZone dateTimeTimeZone)
        {
            // The resulting DateTimeOffset will have the correct offset for the time zone specified in the input object.

            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, DateTimeTimeZone.DateTimeFormat, CultureInfo.InvariantCulture);
            TimeZoneInfo timeZoneInfo = DateTimeTimeZone.GetTimeZoneInfo(dateTimeTimeZone.TimeZone);
            return dateTime.ToDateTimeOffset(timeZoneInfo);
        }
        
        internal static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            TimeSpan offset;
            if (timeZoneInfo.IsAmbiguousTime(dateTime))
            {
                // Ambiguous times happen when during backward transitions, such as the end of daylight saving time.
                // Since we were just told this time is ambiguous, there will always be exactly two offsets in the following array:
                TimeSpan[] offsets = timeZoneInfo.GetAmbiguousTimeOffsets(dateTime);

                // A reasonable common practice is to pick the first occurrence, which is always the largest offset in the array.
                // Ex: 2019-11-03T01:30:00 in the Pacific time zone occurs twice.  First at 1:30 PDT (-07:00), then an hour later
                //     at 1:30 PST (-08:00).  We choose PDT (-07:00) because it comes first sequentially.
                offset = TimeSpan.FromMinutes(Math.Max(offsets[0].TotalMinutes, offsets[1].TotalMinutes));
            }
            else if (timeZoneInfo.IsInvalidTime(dateTime))
            {
                // Invalid times happen during the gap created by a forward transition, such as the start of daylight saving time.
                // While they are not values that actually occur in correct local time, they are sometimes encountered
                // in scenarios such as a scheduled daily task.  In such cases, a reasonable common practice is to advance
                // to a valid local time by the amount of the transition gap (usually 1 hour).
                // Ex: 2019-03-10T02:30:00 does not exist in Pacific time.
                //     The local time went from 01:59:59 PST (-08:00) directly to 03:00:00 PDT (-07:00).
                //     We will advance by 1 hour to 03:30:00 which is in PDT (-07:00).

                // The gap is usually 1 hour, but not always - so it must be calculated
                TimeSpan earlierOffset = timeZoneInfo.GetUtcOffset(dateTime.AddDays(-1));
                TimeSpan laterOffset = timeZoneInfo.GetUtcOffset(dateTime.AddDays(1));
                TimeSpan gap = laterOffset - earlierOffset;

                dateTime = dateTime.Add(gap);
                offset = laterOffset;
            }
            else
            {
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                offset = timeZoneInfo.GetUtcOffset(dateTime);
            }

            return new DateTimeOffset(dateTime, offset);
        }
    }
}

namespace Microsoft.Graph
{
    public partial class DateTimeTimeZone
    {      
        internal const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffK";

        /// <summary>
        /// Converts a Datetime parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTime(DateTime dateTime, string timeZone)
        {
            TimeZoneInfo timeZoneInfo = GetTimeZoneInfo(timeZone);

            // When in Local or Utc kind, we can convert to the time zone specified
            // Which may be a no-op if the value is already in the specified time zone
            // We don't do this for Unspecified kind, as that would infer converting *from* the local time zone
            if (dateTime.Kind != DateTimeKind.Unspecified)
            {
                dateTime = TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo);
            }

            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZone
            };

            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a DatetimeOffset parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTimeOffset(DateTimeOffset dateTimeOffset, string timeZone)
        {
            TimeZoneInfo timeZoneInfo = GetTimeZoneInfo(timeZone);

            // Convert the input value to the time zone specified.
            // If it's already in an offset valid for that time zone, this will be a no-op.
            dateTimeOffset = TimeZoneInfo.ConvertTime(dateTimeOffset, timeZoneInfo);

            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZone
            };

            return dateTimeTimeZone;
        }

        internal static TimeZoneInfo GetTimeZoneInfo(string timeZone)
        {
            // The following is built-in, but is platform dependent.
            // It will use Windows time zones on Windows, and IANA time zones on other platforms.

            return TimeZoneInfo.FindSystemTimeZoneById(timeZone);


            // The following is platform independent, working with either Windows or IANA time zones on any platform.
            // However, it requires a dependency on https://github.com/mj1856/TimeZoneConverter
            // See also https://github.com/dotnet/corefx/issues/11897
            //      and https://github.com/dotnet/corefx/issues/2538
            //
            // return TimeZoneConverter.TZConvert.GetTimeZoneInfo(timeZone);


            // Note that *neither* of the above options map neatly to the list of time zones given in
            // https://docs.microsoft.com/graph/api/resources/datetimetimezone
            // That list seems to include many omissions and some additions and customizations.
            // Those would also need to be handled here, probably by manually mapping the differences to valid IANA time zones.
        }
    }
}
