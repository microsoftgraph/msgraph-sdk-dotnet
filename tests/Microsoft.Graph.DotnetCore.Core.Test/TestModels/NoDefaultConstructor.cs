// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    using Newtonsoft.Json;
    /// <summary>
    /// A property bag class with no default constructor for unit testing purposes.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class NoDefaultConstructor
    {
        static NoDefaultConstructor()
        {

        }

        public NoDefaultConstructor(string parameter)
        {

        }
    }
}
