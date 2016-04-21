// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Serialization
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateConverterTests
    {
        private DateConverter converter;

        [TestInitialize]
        public void Setup()
        {
            this.converter = new DateConverter();
        }

        [TestMethod]
        public void CanConvert_Date()
        {
            Assert.IsTrue(this.converter.CanConvert(typeof(Date)), "Unexpected value for CanConvert.");
        }

        [TestMethod]
        public void CanConvert_InvalidType()
        {
            Assert.IsFalse(this.converter.CanConvert(typeof(DateTime)), "Unexpected value for CanConvert.");
        }
    }
}
