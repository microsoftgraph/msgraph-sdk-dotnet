// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests.Middleware.Options
{
    using System.Net.Http;
    using Xunit;

    public class RedirectHandlerOptionTests
    {
        [Fact]
        public void RedirectHandlerOption_ShouldUseDefaultValuesIfNotSpecified()
        {
            var retryOptions = new RedirectHandlerOption();
            Assert.Equal(RedirectHandlerOption.DEFAULT_MAX_REDIRECT, retryOptions.MaxRedirect);
            Assert.True(retryOptions.ShouldRedirect(null));
        }

        [Fact]
        public void RedirectHandlerOption_RetrytHandlerOption_ShouldThrowMaximumValueExceededExceptionForMaxRedirect()
        {
            ServiceException exception = Assert.Throws<ServiceException>(() => new RedirectHandlerOption() { MaxRedirect = 21 });
            Assert.Equal(exception.Error.Code, ErrorConstants.Codes.MaximumValueExceeded);
            Assert.Equal(exception.Error.Message, string.Format(ErrorConstants.Messages.MaximumValueExceeded, "MaxRedirect", RedirectHandlerOption.MAX_MAX_REDIRECT));
        }

        [Fact]
        public void RedirectHandlerOption_RetrytHandlerOption_ShouldAcceptCorrectValue()
        {
            int maxRedirect = 15;
            var retryOptions = new RedirectHandlerOption() { MaxRedirect = maxRedirect, ShouldRedirect = ShouldRedirect };
            Assert.Equal(maxRedirect, retryOptions.MaxRedirect);
            Assert.Equal(ShouldRedirect, retryOptions.ShouldRedirect);
        }

        private bool ShouldRedirect(HttpResponseMessage rwsponse)
        {
            return false;
        }
    }
}
