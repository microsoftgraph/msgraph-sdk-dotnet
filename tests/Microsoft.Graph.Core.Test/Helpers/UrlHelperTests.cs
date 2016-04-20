// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Helpers
{
    using System;

    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UrlHelperTests
    {
        [TestMethod]
        public void GetQueryOptions_EmptyFragment()
        {
            var uri = new Uri("https://localhost#");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(0, queryValues.Count, "Unexpected query values returned.");
        }

        [TestMethod]
        public void GetQueryOptions_EmptyQueryString()
        {
            var uri = new Uri("https://localhost?");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(0, queryValues.Count, "Unexpected query values returned.");
        }

        [TestMethod]
        public void GetQueryOptions_NoQueryString()
        {
            var uri = new Uri("https://localhost");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(0, queryValues.Count, "Unexpected query values returned.");
        }

        [TestMethod]
        public void GetQueryOptions_MultipleFragments()
        {
            var uri = new Uri("https://localhost#key=value&key2=value%202");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(2, queryValues.Count, "Unexpected query values returned.");
            Assert.AreEqual("value", queryValues["key"], "Unexpected query value.");
            Assert.AreEqual("value 2", queryValues["key2"], "Unexpected query value.");
        }

        [TestMethod]
        public void GetQueryOptions_SingleFragment()
        {
            var uri = new Uri("https://localhost#key=value");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(1, queryValues.Count, "Unexpected query values returned.");
            Assert.AreEqual("value", queryValues["key"], "Unexpected query value.");
        }

        [TestMethod]
        public void GetQueryOptions_MultipleQueryOptions()
        {
            var uri = new Uri("https://localhost?key=value&key2=value%202");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(2, queryValues.Count, "Unexpected query values returned.");
            Assert.AreEqual("value 2", queryValues["key2"], "Unexpected query value.");
        }

        [TestMethod]
        public void GetQueryOptions_SingleQueryOption()
        {
            var uri = new Uri("https://localhost?key=value");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(1, queryValues.Count, "Unexpected query values returned.");
            Assert.AreEqual("value", queryValues["key"], "Unexpected query value.");
        }

        [TestMethod]
        public void GetQueryOptions_TrailingAmpersand()
        {
            var uri = new Uri("https://localhost?key=value&");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.AreEqual(1, queryValues.Count, "Unexpected query values returned.");
            Assert.AreEqual("value", queryValues["key"], "Unexpected query value.");
        }
    }
}
