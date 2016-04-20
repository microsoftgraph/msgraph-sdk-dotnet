// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System;

    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ServiceExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsMatch_ErrorCodeRequired()
        {
            var serviceException = new ServiceException(
                new Error
                {
                    Code = "errorCode",
                });

            serviceException.IsMatch(null);
        }

        [TestMethod]
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

            Assert.IsTrue(serviceException.IsMatch("errorcodematch"), "Matching error code not found.");
        }

        [TestMethod]
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

            Assert.IsFalse(serviceException.IsMatch("noMatch"), "Matching error code found.");
        }

        [TestMethod]
        public void ToString_ErrorNotNull()
        {
            var error = new Error
            {
                Code = "code",
            };

            var serviceException = new ServiceException(error);

            Assert.AreEqual(error.ToString(), serviceException.ToString(), "Unexpected string response returned.");
        }

        [TestMethod]
        public void ToString_ErrorNull()
        {
            var serviceException = new ServiceException(null);

            Assert.IsNull(serviceException.ToString(), "Unexpected string response returned.");
        }
    }
}
