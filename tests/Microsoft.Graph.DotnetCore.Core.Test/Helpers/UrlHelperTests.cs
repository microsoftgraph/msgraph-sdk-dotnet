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
    public class UrlHelperTests
    {
        [Fact]
        public void GetQueryOptions_EmptyFragment()
        {
            var uri = new Uri("https://localhost#");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(0, queryValues.Count);
        }

        [Fact]
        public void GetQueryOptions_EmptyQueryString()
        {
            var uri = new Uri("https://localhost?");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(0, queryValues.Count);
        }

        [Fact]
        public void GetQueryOptions_NoQueryString()
        {
            var uri = new Uri("https://localhost");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(0, queryValues.Count);
        }

        [Fact]
        public void GetQueryOptions_MultipleFragments()
        {
            var uri = new Uri("https://localhost#key=value&key2=value%202");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(2, queryValues.Count);
            Assert.Equal("value", queryValues["key"]);
            Assert.Equal("value 2", queryValues["key2"]);
        }

        [Fact]
        public void GetQueryOptions_SingleFragment()
        {
            var uri = new Uri("https://localhost#key=value");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(1, queryValues.Count);
            Assert.Equal("value", queryValues["key"]);
        }

        [Fact]
        public void GetQueryOptions_MultipleQueryOptions()
        {
            var uri = new Uri("https://localhost?key=value&key2=value%202");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(2, queryValues.Count);
            Assert.Equal("value 2", queryValues["key2"]);
        }

        [Fact]
        public void GetQueryOptions_SingleQueryOption()
        {
            var uri = new Uri("https://localhost?key=value");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(1, queryValues.Count);
            Assert.Equal("value", queryValues["key"]);
        }

        [Fact]
        public void GetQueryOptions_TrailingAmpersand()
        {
            var uri = new Uri("https://localhost?key=value&");

            var queryValues = UrlHelper.GetQueryOptions(uri);

            Assert.Equal(1, queryValues.Count);
            Assert.Equal("value", queryValues["key"]);
        }
    }
}
