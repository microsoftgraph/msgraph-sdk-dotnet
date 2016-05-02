// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.TestModels
{
    using System.Collections.Generic;

    public class CustomRequest : BaseRequest
    {
        internal static readonly string SdkHeaderName = "Name";
        internal static readonly string SdkHeaderValue = "Value";

        public CustomRequest(string baseUrl, IBaseClient baseClient, IEnumerable<Option> options = null)
            : base(baseUrl, baseClient, options)
        {
            this.sdkVersionHeaderName = CustomRequest.SdkHeaderName;
            this.sdkVersionHeaderValue = CustomRequest.SdkHeaderValue;
        }
    }
}
