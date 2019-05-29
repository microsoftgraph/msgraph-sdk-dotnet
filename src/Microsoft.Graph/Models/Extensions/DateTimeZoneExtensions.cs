// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;

namespace Microsoft.Graph.Extensions
{
    /// <summary>
    /// Implements Content Converter Extensions
    /// </summary>
    public static class DateTimeZoneExtensions
    {
        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTime
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <param name="dateFormat"></param>
        /// <param name="provider">provide CultureInfo.InvariantCulture as the default</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeTimeZone dateTimeTimeZone, string dateFormat, IFormatProvider provider)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, dateFormat, provider);
            return dateTime;
        }

        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTimeOffset
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <param name="dateFormat"></param>
        /// <param name="provider">provide CultureInfo.InvariantCulture as the default</param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTimeTimeZone dateTimeTimeZone, string dateFormat, IFormatProvider provider)
        {
            DateTime dateTime = DateTimeOffset.ParseExact(dateTimeTimeZone.DateTime, dateFormat, provider).UtcDateTime;
            return dateTime;
        }

        /// <summary>
        /// Converts a Datetime parameter to its equivalent DateTimeTimeZone Complex Type
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <param name="dateTime"></param>
        /// <param name="dateFormat"></param>
        /// <param name="provider">provide CultureInfo.InvariantCulture as the default</param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTime(this DateTimeTimeZone dateTimeTimeZone, DateTime dateTime, string dateFormat, IFormatProvider provider)
        {
            dateTimeTimeZone.DateTime = dateTime.ToUniversalTime().ToString(dateFormat, provider);
            return dateTimeTimeZone;
        }

        /// <summary>
        /// Converts a DatetimeOffset parameter to its equivalent DateTimeTimeZone Complex Type
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <param name="dateTimeOffset"></param>
        /// <param name="dateFormat"></param>
        /// <param name="provider">provide CultureInfo.InvariantCulture as the default</param>
        /// <returns></returns>
        public static DateTimeTimeZone FromDateTimeOffset(this DateTimeTimeZone dateTimeTimeZone, DateTimeOffset dateTimeOffset, string dateFormat, IFormatProvider provider)
        {
            dateTimeTimeZone.DateTime = dateTimeOffset.ToUniversalTime().ToString(dateFormat, provider);
            return dateTimeTimeZone;
        }
    }
}