// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Serialization
{
    using System;
    using Xunit;

    public class DurationConverterTests
    {
        private DurationConverter converter;

        public DurationConverterTests()
        {
            this.converter = new DurationConverter();
        }

        [Fact]
        public void CanConvert_Duration()
        {
            Assert.True(this.converter.CanConvert(typeof(Duration)));
        }

        [Fact]
        public void CanConvert__Duration_InvalidType()
        {
            Assert.False(this.converter.CanConvert(typeof(DateTime)));
        }

        [Fact]
        public void Duration_CanDeserialize()
        {
            var json = "\"PT2H\"";
            var serializer = new Serializer();
            var derivedType = serializer.DeserializeObject<Duration>(json);
            Assert.NotNull(derivedType);
            Assert.Equal(2, derivedType.TimeSpan.Hours);
        }
    }
}
