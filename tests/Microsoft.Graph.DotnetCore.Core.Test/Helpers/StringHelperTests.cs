// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Helpers
{
    public class StringHelperTests
    {
        [Fact]
        public void ConvertTypeToLowerCamelCase()
        {
            var expectedTypeString = "microsoft.graph.type";

            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase("Microsoft.Graph.Type");

            Assert.Equal(expectedTypeString, returnedTypeString);
        }

        [Fact]
        public void ConvertTypeToLowerCamelCase_NoNamespace()
        {
            var expectedTypeString = "newType";

            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase("NewType");

            Assert.Equal(expectedTypeString, returnedTypeString);
        }

        [Fact]
        public void ConvertTypeToLowerCamelCase_NullTypeString()
        {
            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase(null);

            Assert.Null(returnedTypeString);
        }

        [Fact]
        public void ConvertTypeToTitleCase()
        {
            var expectedTypeString = "Microsoft.Graph.Type";

            var returnedTypeString = StringHelper.ConvertTypeToTitleCase("microsoft.graph.type");

            Assert.Equal(expectedTypeString, returnedTypeString);
        }

        [Fact]
        public void ConvertTypeToTitleCase_NoNamespace()
        {
            var expectedTypeString = "NewType";

            var returnedTypeString = StringHelper.ConvertTypeToTitleCase("newType");

            Assert.Equal(expectedTypeString, returnedTypeString);
        }

        [Fact]
        public void ConvertTypeToTitleCase_NullTypeString()
        {
            var returnedTypeString = StringHelper.ConvertTypeToTitleCase(null);

            Assert.Null(returnedTypeString);
        }
    }
}
