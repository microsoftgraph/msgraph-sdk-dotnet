// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;

    using Newtonsoft.Json;

    [JsonConverter(typeof(EdmDateConverter))]
    public class EdmDate
    {
        internal EdmDate(DateTimeOffset dateTimeOffset)
            : this(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day)
        {
        }

        public EdmDate(int year, int month, int day)
        {
            this.DateTimeOffset = new DateTimeOffset(new DateTime(year, month, day));
        }

        internal DateTimeOffset DateTimeOffset { get; set; }

        public int Year
        {
            get
            {
                return this.DateTimeOffset.Year;
            }
        }

        public int Month
        {
            get
            {
                return this.DateTimeOffset.Month;
            }
        }

        public int Day
        {
            get
            {
                return this.DateTimeOffset.Day;
            }
        }
    }
}
