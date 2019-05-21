// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    using System.Collections.Generic;
    public class CustomRequest : BaseRequest
    {
        public CustomRequest(string baseUrl, IBaseClient baseClient, IEnumerable<Option> options = null)
            : base(baseUrl, baseClient, options)
        {
        }
    }
}
