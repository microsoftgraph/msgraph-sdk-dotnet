// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;

    using Newtonsoft.Json;

    [JsonConverter(typeof(DateConverter))]
    public class Date
    {
        internal Date(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        public Date(int year, int month, int day)
            : this(new DateTime(year, month, day))
        {
        }

        internal DateTime DateTime { get; set; }

        public int Year
        {
            get
            {
                return this.DateTime.Year;
            }
        }

        public int Month
        {
            get
            {
                return this.DateTime.Month;
            }
        }

        public int Day
        {
            get
            {
                return this.DateTime.Day;
            }
        }

        public override string ToString()
        {
            return this.DateTime.ToString("yyyy-MM-dd");
        }
    }
}
