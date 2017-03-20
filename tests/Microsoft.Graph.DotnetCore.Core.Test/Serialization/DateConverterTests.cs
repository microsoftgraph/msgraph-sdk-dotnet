// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Serialization
{
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
    }
}
