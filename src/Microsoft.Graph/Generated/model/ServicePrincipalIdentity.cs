// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.
// <auto-generated/>

// Template Source: ComplexType.cs.tt

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The type ServicePrincipalIdentity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class ServicePrincipalIdentity : Identity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePrincipalIdentity"/> class.
        /// </summary>
        public ServicePrincipalIdentity()
        {
            this.ODataType = "microsoft.graph.servicePrincipalIdentity";
        }

        /// <summary>
        /// Gets or sets appId.
        /// The application identifier of the service principal.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "appId", Required = Newtonsoft.Json.Required.Default)]
        public string AppId { get; set; }
    
    }
}
