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
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);

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
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);
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
        /// <summary>
        /// Converts the dateTime to a DateTimeTimeZone object
        /// <para>This method assumes the value is expressed on the same timezone as the target mailbox and the local machine</para>
        /// </summary>
        /// <param name="dateTime">>A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <returns></returns>
        public static DateTimeTimeZone ToDateTimeTimeZone(this DateTime dateTime)
        {
            return DateTimeTimeZone.FromDateTime(dateTime);
        }
        /// <summary>
        /// Converts the dateTime to a DateTimeTimeZone object
        /// </summary>
        /// <param name="dateTime">>A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <param name="timeZoneInfo">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone ToDateTimeTimeZone(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            return DateTimeTimeZone.FromDateTime(dateTime, timeZoneInfo);
        }
        /// <summary>
        /// Converts the dateTimeOffset to a DateTimeTimeZone object
        /// <para>This method assumes the value is expressed on the same timezone as the target mailbox and the local machine</para>
        /// </summary>
        /// <param name="dateTimeOffset">>A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <returns></returns>
        public static DateTimeTimeZone ToDateTimeTimeZone(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeTimeZone.FromDateTimeOffset(dateTimeOffset);
        }
        /// <summary>
        /// Converts the dateTimeOffset to a DateTimeTimeZone object
        /// </summary>
        /// <param name="dateTimeOffset">>A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <param name="timeZone">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone ToDateTimeTimeZone(this DateTimeOffset dateTimeOffset, string timeZone)
        {
            return DateTimeTimeZone.FromDateTimeOffset(dateTimeOffset, timeZone);
        }
        /// <summary>
        /// Converts the dateTimeOffset to a DateTimeTimeZone object
        /// </summary>
        /// <param name="dateTimeOffset">>A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <param name="timeZoneInfo">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone ToDateTimeTimeZone(this DateTimeOffset dateTimeOffset, TimeZoneInfo timeZoneInfo)
        {
            return DateTimeTimeZone.FromDateTimeOffset(dateTimeOffset, timeZoneInfo);
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
        /// <para>This method assumes the value is expressed on the same timezone as the target mailbox and the local machine</para>
        /// </summary>
        /// <param name="dateTime">A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTime(DateTime dateTime)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = string.Empty
            };

            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a Datetime parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTime">A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <param name="timeZone">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTime(DateTime dateTime, string timeZone)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZone
            };

            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a Datetime parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTime">A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).</param>
        /// <param name="timeZoneInfo">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTime(DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZoneInfo.Id
            };
            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a DatetimeOffset parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// <para>This method assumes the value is expressed on the same timezone as the target mailbox and the local machine</para>
        /// </summary>
        /// <param name="dateTimeOffset">Represents a point in time, typically expressed as a date and time of day, relative to Coordinated Universal Time (UTC).</param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = string.Empty
            };

            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a DatetimeOffset parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTimeOffset">Represents a point in time, typically expressed as a date and time of day, relative to Coordinated Universal Time (UTC).</param>
        /// <param name="timeZone">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTimeOffset(DateTimeOffset dateTimeOffset, string timeZone)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZone
            };

            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a DatetimeOffset parameter to its equivalent DateTimeTimeZone Complex Type given its TimeZone
        /// </summary>
        /// <param name="dateTimeOffset">Represents a point in time, typically expressed as a date and time of day, relative to Coordinated Universal Time (UTC).</param>
        /// <param name="timeZoneInfo">The expected values for timeZone are specified here: https://docs.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0 </param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTimeOffset(DateTimeOffset dateTimeOffset, TimeZoneInfo timeZoneInfo)
        {
            DateTimeTimeZone dateTimeTimeZone = new DateTimeTimeZone
            {
                DateTime = dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                TimeZone = timeZoneInfo.Id
            };

            return dateTimeTimeZone;
        }
    }
}
