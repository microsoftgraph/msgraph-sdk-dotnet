// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    /// <summary>
    /// A property bag class for testing derived type deserialization.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    [DataContract]
    public class DerivedTypeClass : AbstractEntityType
    {
        /// <summary>
        /// Gets or sets enumType.
        /// </summary>
        [DataMember(Name = "enumType", EmitDefaultValue = false, IsRequired = false)]
        public EnumType? EnumType { get; set; }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }
    }
}
