// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
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
