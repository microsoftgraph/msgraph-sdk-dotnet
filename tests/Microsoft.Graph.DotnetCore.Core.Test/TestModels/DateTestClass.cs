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
    /// Test class for testing serialization of Date.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    [DataContract]
    public class DateTestClass
    {
        /// <summary>
        /// Gets or sets nullableDate.
        /// </summary>
        [DataMember(Name = "nullableDate", EmitDefaultValue = true, IsRequired = false)]
        public Date NullableDate { get; set; }

        /// <summary>
        /// Gets or sets dateCollection.
        /// </summary>
        [DataMember(Name = "dateCollection", EmitDefaultValue = false, IsRequired = false)]
        public IEnumerable<Date> DateCollection { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [DataMember(Name = "invalidType", EmitDefaultValue = false, IsRequired = false)]
        public int? InvalidType { get; set; }
    }
}
