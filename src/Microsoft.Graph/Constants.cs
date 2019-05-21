// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    /// <summary>
    /// Constants used for navigating Graph
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// URL segment constants
        /// </summary>
        public static class Url
        {
            /// <summary>
            /// The AppRoot folder
            /// </summary>
            public const string AppRoot = "approot";

            /// <summary>
            /// The Deleted Items folder
            /// </summary>
            public const string DeletedItems = "DeletedItems";

            /// <summary>
            /// The Drafts folder
            /// </summary>
            public const string Drafts = "Drafts";

            /// <summary>
            /// The base URL format for Graph
            /// </summary>
            public const string GraphBaseUrlFormatString = "https://graph.microsoft.com/{0}";

            /// <summary>
            /// The Inbox folder
            /// </summary>
            public const string Inbox = "Inbox";

            /// <summary>
            /// The Sent Items folder
            /// </summary>
            public const string SentItems = "SentItems";
        }
    }
}
