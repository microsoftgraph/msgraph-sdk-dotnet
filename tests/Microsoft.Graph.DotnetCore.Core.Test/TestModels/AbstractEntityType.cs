// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    /// <summary>
    /// A class to test abstract entity serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    [DataContract]
    public class AbstractEntityType
    {
        protected AbstractEntityType()
        {

        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false, IsRequired = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
