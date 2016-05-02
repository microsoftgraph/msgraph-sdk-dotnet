// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Helpers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void ConvertTypeToLowerCamelCase()
        {
            var expectedTypeString = "microsoft.graph.type";

            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase("Microsoft.Graph.Type");

            Assert.AreEqual(expectedTypeString, returnedTypeString, "Unexpected string returned.");
        }

        [TestMethod]
        public void ConvertTypeToLowerCamelCase_NoNamespace()
        {
            var expectedTypeString = "newType";

            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase("NewType");

            Assert.AreEqual(expectedTypeString, returnedTypeString, "Unexpected string returned.");
        }

        [TestMethod]
        public void ConvertTypeToLowerCamelCase_NullTypeString()
        {
            var returnedTypeString = StringHelper.ConvertTypeToLowerCamelCase(null);

            Assert.IsNull(returnedTypeString, "Unexpected string returned.");
        }

        [TestMethod]
        public void ConvertTypeToTitleCase()
        {
            var expectedTypeString = "Microsoft.Graph.Type";

            var returnedTypeString = StringHelper.ConvertTypeToTitleCase("microsoft.graph.type");

            Assert.AreEqual(expectedTypeString, returnedTypeString, "Unexpected string returned.");
        }

        [TestMethod]
        public void ConvertTypeToTitleCase_NoNamespace()
        {
            var expectedTypeString = "NewType";

            var returnedTypeString = StringHelper.ConvertTypeToTitleCase("newType");

            Assert.AreEqual(expectedTypeString, returnedTypeString, "Unexpected string returned.");
        }

        [TestMethod]
        public void ConvertTypeToTitleCase_NullTypeString()
        {
            var returnedTypeString = StringHelper.ConvertTypeToTitleCase(null);

            Assert.IsNull(returnedTypeString, "Unexpected string returned.");
        }
    }
}
