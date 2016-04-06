// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Serialization
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EdmDateConverterTests
    {
        private EdmDateConverter converter;

        [TestInitialize]
        public void Setup()
        {
            this.converter = new EdmDateConverter();
        }

        [TestMethod]
        public void CanConvert_EdmDate()
        {
            Assert.IsTrue(this.converter.CanConvert(typeof(EdmDate)), "Unexpected value for CanConvert.");
        }

        [TestMethod]
        public void CanConvert_InvalidType()
        {
            Assert.IsFalse(this.converter.CanConvert(typeof(DateTimeOffset)), "Unexpected value for CanConvert.");
        }
    }
}
