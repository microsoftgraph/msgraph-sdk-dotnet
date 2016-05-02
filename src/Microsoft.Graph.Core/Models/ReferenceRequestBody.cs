// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ReferenceRequestBody
    {
        [DataMember(Name = "@odata.id", EmitDefaultValue = false, IsRequired = false)]
        public string ODataId { get; set; }
    }
}
