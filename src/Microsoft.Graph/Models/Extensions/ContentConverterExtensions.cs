// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;

namespace Microsoft.Graph.Extensions
{
    /// <summary>
    /// Implements Content Converter Extensions
    /// </summary>
    public static class ContentConverterExtensions
    {
        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTime
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeTimeZone dateTimeTimeZone)
        {
            DateTime dateTime = DateTime.Parse(dateTimeTimeZone.DateTime);
            return dateTime;
        }

        /// <summary>
        /// Converts DateTimeTimeZone which is a Complex Type to DateTimeOffset
        /// </summary>
        /// <param name="dateTimeTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTimeTimeZone dateTimeTimeZone)
        {
            DateTime dateTime = DateTimeOffset.Parse(dateTimeTimeZone.DateTime).UtcDateTime;
            return dateTime;
        }
    }
}