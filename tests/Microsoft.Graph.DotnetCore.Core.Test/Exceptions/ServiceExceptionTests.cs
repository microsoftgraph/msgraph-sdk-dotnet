// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Exceptions
{
    using System;
    using Xunit;
    public class ServiceExceptionTests
    {
        [Fact]
        public void IsMatch_ErrorCodeRequired()
        {
            var serviceException = new ServiceException(
                new Error
                {
                    Code = "errorCode",
                });

            Assert.Throws<ArgumentException>(() => serviceException.IsMatch(null));
        }

        [Fact]
        public void IsMatch_NestedErrors()
        {
            var serviceException = new ServiceException(
                new Error
                {
                    Code = "errorCode",
                    InnerError = new Error
                    {
                        Code = "differentErrorCode",
                        InnerError = new Error
                        {
                            Code = "errorCodeMatch",
                        }
                    }
                });

            Assert.True(serviceException.IsMatch("errorcodematch"));
        }

        [Fact]
        public void IsMatch_NoMatch()
        {
            var serviceException = new ServiceException(
                new Error
                {
                    Code = "errorCode",
                    InnerError = new Error
                    {
                        Code = "differentErrorCode",
                        InnerError = new Error
                        {
                            Code = "errorCodeMatch",
                        }
                    }
                });

            Assert.False(serviceException.IsMatch("noMatch"));
        }

        [Fact(Skip = "Changed the signature of ServiceException.ToString() in ccecc486cce5769313c0cb59ab56142d1b43ce5a")]
        public void ToString_ErrorNotNull()
        {
            var error = new Error
            {
                Code = "code",
            };

            var serviceException = new ServiceException(error);

            Assert.Equal(error.ToString(), serviceException.ToString());
        }

        [Fact(Skip = "Changed the signature of ServiceException.ToString() in ccecc486cce5769313c0cb59ab56142d1b43ce5a")]
        public void ToString_ErrorNull()
        {
            var serviceException = new ServiceException(null);

            Assert.Null(serviceException.ToString());
        }
    }
}
