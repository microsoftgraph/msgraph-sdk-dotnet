using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of application entities.</summary>
    public class ExtensionProperty : DirectoryObject, IParsable {
        /// <summary>Display name of the application object on which this extension property is defined. Read-only.</summary>
        public string AppDisplayName {
            get { return BackingStore?.Get<string>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
        /// <summary>Specifies the data type of the value the extension property can hold. Following values are supported. Not nullable. Binary - 256 bytes maximumBooleanDateTime - Must be specified in ISO 8601 format. Will be stored in UTC.Integer - 32-bit value.LargeInteger - 64-bit value.String - 256 characters maximum</summary>
        public string DataType {
            get { return BackingStore?.Get<string>("dataType"); }
            set { BackingStore?.Set("dataType", value); }
        }
        /// <summary>Indicates if this extension property was synced from on-premises active directory using Azure AD Connect. Read-only.</summary>
        public bool? IsSyncedFromOnPremises {
            get { return BackingStore?.Get<bool?>("isSyncedFromOnPremises"); }
            set { BackingStore?.Set("isSyncedFromOnPremises", value); }
        }
        /// <summary>Name of the extension property. Not nullable. Supports $filter (eq).</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>Following values are supported. Not nullable. UserGroupAdministrativeUnitApplicationDeviceOrganization</summary>
        public List<string> TargetObjects {
            get { return BackingStore?.Get<List<string>>("targetObjects"); }
            set { BackingStore?.Set("targetObjects", value); }
        }
        /// <summary>
        /// Instantiates a new extensionProperty and sets the default values.
        /// </summary>
        public ExtensionProperty() : base() {
            OdataType = "#microsoft.graph.extensionProperty";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
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
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
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
