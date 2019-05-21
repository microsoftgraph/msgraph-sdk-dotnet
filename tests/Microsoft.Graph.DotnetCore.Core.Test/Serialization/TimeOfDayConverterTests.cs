// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Serialization
{
    using System;
    using Xunit;

    public class TimeOfDayConverterTests
    {
        private TimeOfDayConverter converter;

        public TimeOfDayConverterTests()
        {
            this.converter = new TimeOfDayConverter();
        }

        [Fact]
        public void CanConvert_TimeOfDay()
        {
            Assert.True(this.converter.CanConvert(typeof(TimeOfDay)));
        }

        [Fact]
        public void CanConvert_TimeOfDay_InvalidType()
        {
            Assert.False(this.converter.CanConvert(typeof(DateTime)));
        }
    }
}
