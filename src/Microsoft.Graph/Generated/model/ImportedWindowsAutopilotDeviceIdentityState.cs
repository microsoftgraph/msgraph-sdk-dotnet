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
    using System.Text.Json.Serialization;

    /// <summary>
    /// The type ImportedWindowsAutopilotDeviceIdentityState.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter<ImportedWindowsAutopilotDeviceIdentityState>))]
    public partial class ImportedWindowsAutopilotDeviceIdentityState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportedWindowsAutopilotDeviceIdentityState"/> class.
        /// </summary>
        public ImportedWindowsAutopilotDeviceIdentityState()
        {
            this.ODataType = "microsoft.graph.importedWindowsAutopilotDeviceIdentityState";
        }

        /// <summary>
        /// Gets or sets deviceErrorCode.
        /// Device error code reported by Device Directory Service(DDS).
        /// </summary>
        [JsonPropertyName("deviceErrorCode")]
        public Int32? DeviceErrorCode { get; set; }
    
        /// <summary>
        /// Gets or sets deviceErrorName.
        /// Device error name reported by Device Directory Service(DDS).
        /// </summary>
        [JsonPropertyName("deviceErrorName")]
        public string DeviceErrorName { get; set; }
    
        /// <summary>
        /// Gets or sets deviceImportStatus.
        /// Device status reported by Device Directory Service(DDS). Possible values are: unknown, pending, partial, complete, error.
        /// </summary>
        [JsonPropertyName("deviceImportStatus")]
        public ImportedWindowsAutopilotDeviceIdentityImportStatus? DeviceImportStatus { get; set; }
    
        /// <summary>
        /// Gets or sets deviceRegistrationId.
        /// Device Registration ID for successfully added device reported by Device Directory Service(DDS).
        /// </summary>
        [JsonPropertyName("deviceRegistrationId")]
        public string DeviceRegistrationId { get; set; }
    
        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>
        /// Gets or sets @odata.type.
        /// </summary>
        [JsonPropertyName("@odata.type")]
        public string ODataType { get; set; }
    
    }
}