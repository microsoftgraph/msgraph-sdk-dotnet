using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class ExtensionProperty : DirectoryObject, IParsable {
        /// <summary>Display name of the application object on which this extension property is defined. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AppDisplayName {
            get { return BackingStore?.Get<string?>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
#nullable restore
#else
        public string AppDisplayName {
            get { return BackingStore?.Get<string>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
#endif
        /// <summary>Specifies the data type of the value the extension property can hold. Following values are supported. Not nullable. Binary - 256 bytes maximumBooleanDateTime - Must be specified in ISO 8601 format. Will be stored in UTC.Integer - 32-bit value.LargeInteger - 64-bit value.String - 256 characters maximum</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DataType {
            get { return BackingStore?.Get<string?>("dataType"); }
            set { BackingStore?.Set("dataType", value); }
        }
#nullable restore
#else
        public string DataType {
            get { return BackingStore?.Get<string>("dataType"); }
            set { BackingStore?.Set("dataType", value); }
        }
#endif
        /// <summary>Indicates if this extension property was synced from on-premises active directory using Azure AD Connect. Read-only.</summary>
        public bool? IsSyncedFromOnPremises {
            get { return BackingStore?.Get<bool?>("isSyncedFromOnPremises"); }
            set { BackingStore?.Set("isSyncedFromOnPremises", value); }
        }
        /// <summary>Name of the extension property. Not nullable. Supports $filter (eq).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name {
            get { return BackingStore?.Get<string?>("name"); }
            set { BackingStore?.Set("name", value); }
        }
#nullable restore
#else
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
#endif
        /// <summary>Following values are supported. Not nullable. UserGroupAdministrativeUnitApplicationDeviceOrganization</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? TargetObjects {
            get { return BackingStore?.Get<List<string>?>("targetObjects"); }
            set { BackingStore?.Set("targetObjects", value); }
        }
#nullable restore
#else
        public List<string> TargetObjects {
            get { return BackingStore?.Get<List<string>>("targetObjects"); }
            set { BackingStore?.Set("targetObjects", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new extensionProperty and sets the default values.
        /// </summary>
        public ExtensionProperty() : base() {
            OdataType = "#microsoft.graph.extensionProperty";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ExtensionProperty CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ExtensionProperty();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appDisplayName", n => { AppDisplayName = n.GetStringValue(); } },
                {"dataType", n => { DataType = n.GetStringValue(); } },
                {"isSyncedFromOnPremises", n => { IsSyncedFromOnPremises = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"targetObjects", n => { TargetObjects = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appDisplayName", AppDisplayName);
            writer.WriteStringValue("dataType", DataType);
            writer.WriteBoolValue("isSyncedFromOnPremises", IsSyncedFromOnPremises);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfPrimitiveValues<string>("targetObjects", TargetObjects);
        }
    }
}
