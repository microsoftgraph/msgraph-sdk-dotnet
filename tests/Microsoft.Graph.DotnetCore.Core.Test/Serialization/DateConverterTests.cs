// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Serialization
{
    using System;
    using Xunit;
    public class DateConverterTests
    {
        private DateConverter converter;

        public DateConverterTests()
        {
            this.converter = new DateConverter();
        }

        [Fact]
        public void CanConvert_Date()
        {
            Assert.True(this.converter.CanConvert(typeof(Date)));
        }

        [Fact]
        public void CanConvert_InvalidType()
        {
            Assert.False(this.converter.CanConvert(typeof(DateTime)));
        }

        [Fact]
        public void SerializerRoundTripsDates()
        {
            var eventIn = new Event { Start = new DateTimeTimeZone { DateTime = "2017-10-11T07:30:00.0000+00:00", TimeZone = "UTC" } };
            var serializer = new Serializer();
            var json = serializer.SerializeObject(eventIn);
            var eventRoundTrip = serializer.DeserializeObject<Event>(json);

            Assert.Equal(eventIn.Start.DateTime, eventRoundTrip.Start.DateTime);
        }
    }
}
