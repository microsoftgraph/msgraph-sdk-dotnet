// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    internal static class ErrorConstants
    {
        internal static class Codes
        {
            internal static string GeneralException = "generalException";

            internal static string InvalidRequest = "invalidRequest";

            internal static string ItemNotFound = "itemNotFound";

            internal static string NotAllowed = "notAllowed";

            internal static string Timeout = "timeout";

            internal static string TooManyRedirects = "tooManyRedirects";
        }

        internal static class Messages
        {
            internal static string AuthenticationProviderMissing = "Authentication provider is required before sending a request.";

            internal static string BaseUrlMissing = "Base URL cannot be null or empty.";

            internal static string InvalidTypeForDateConverter = "DateConverter can only serialize objects of type Date.";

            internal static string LocationHeaderNotSetOnRedirect = "Location header not present in redirection response.";

            internal static string OverallTimeoutCannotBeSet = "Overall timeout cannot be set after the first request is sent.";

            internal static string RequestTimedOut = "The request timed out.";

            internal static string RequestUrlMissing = "Request URL is required to send a request.";

            internal static string TooManyRedirectsFormatString = "More than {0} redirects encountered while sending the request.";

            internal static string UnableToCreateInstanceOfTypeFormatString = "Unable to create an instance of type {0}.";

            internal static string UnableToDeserializeDate = "Unable to deserialize the returned Date.";

            internal static string UnexpectedExceptionOnSend = "An error occurred sending the request.";

            internal static string UnexpectedExceptionResponse = "Unexpected exception returned from the service.";
        }
    }
}
