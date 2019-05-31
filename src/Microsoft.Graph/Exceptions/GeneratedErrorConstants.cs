// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    internal static class GeneratedErrorConstants
    {
        internal static class Codes
        {
            internal static string NotAllowed = "notAllowed";
        }

        internal static class Messages
        {
            internal static string ResponseObjectUsedForUpdate = "Do not use objects returned in a response for updating an object in Microsoft Graph. " +
                                                                 "Create a new {0} object and only set the updated properties on it.";
        }
    }
}
