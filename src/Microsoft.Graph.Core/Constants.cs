// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core
{
    public static class Constants
    {
        public static class Headers
        {
            public const string Bearer = "Bearer";
            
            public const string SdkVersionHeaderName = "SdkVersion";

            public const string SdkVersionHeaderValueFormatString = "{0}-{1}.{2}.{3}";

            public const string FormUrlEncodedContentType = "application/x-www-form-urlencoded";

            public const string ThrowSiteHeaderName = "X-ThrowSite";
        }

        public static class Serialization
        {
            public const string ODataType = "@odata.type";
        }
    }
}
