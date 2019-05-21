// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    using System.Runtime.Serialization;
    /// <summary>
    /// Test class for testing serialization of an IEnumerable of Date.
    /// </summary>
    [DataContract]
    public class CollectionPageInstance : CollectionPage<DerivedTypeClass>, ICollectionPageInstance
    {
    }
}
