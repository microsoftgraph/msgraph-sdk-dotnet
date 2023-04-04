using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class DefaultUserRolePermissions : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Indicates whether the default user role can create applications.</summary>
        public bool? AllowedToCreateApps {
            get { return BackingStore?.Get<bool?>("allowedToCreateApps"); }
            set { BackingStore?.Set("allowedToCreateApps", value); }
        }
        /// <summary>Indicates whether the default user role can create security groups.</summary>
        public bool? AllowedToCreateSecurityGroups {
            get { return BackingStore?.Get<bool?>("allowedToCreateSecurityGroups"); }
            set { BackingStore?.Set("allowedToCreateSecurityGroups", value); }
        }
        /// <summary>The allowedToReadBitlockerKeysForOwnedDevice property</summary>
        public bool? AllowedToReadBitlockerKeysForOwnedDevice {
            get { return BackingStore?.Get<bool?>("allowedToReadBitlockerKeysForOwnedDevice"); }
            set { BackingStore?.Set("allowedToReadBitlockerKeysForOwnedDevice", value); }
        }
        /// <summary>Indicates whether the default user role can read other users.</summary>
        public bool? AllowedToReadOtherUsers {
            get { return BackingStore?.Get<bool?>("allowedToReadOtherUsers"); }
            set { BackingStore?.Set("allowedToReadOtherUsers", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>Indicates if user consent to apps is allowed, and if it is, which permission to grant consent and which app consent policy (permissionGrantPolicy) govern the permission for users to grant consent. Value should be in the format managePermissionGrantsForSelf.{id}, where {id} is the id of a built-in or custom app consent policy. An empty list indicates user consent to apps is disabled.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? PermissionGrantPoliciesAssigned {
            get { return BackingStore?.Get<List<string>?>("permissionGrantPoliciesAssigned"); }
            set { BackingStore?.Set("permissionGrantPoliciesAssigned", value); }
        }
#nullable restore
#else
        public List<string> PermissionGrantPoliciesAssigned {
            get { return BackingStore?.Get<List<string>>("permissionGrantPoliciesAssigned"); }
            set { BackingStore?.Set("permissionGrantPoliciesAssigned", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new defaultUserRolePermissions and sets the default values.
        /// </summary>
        public DefaultUserRolePermissions() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static DefaultUserRolePermissions CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DefaultUserRolePermissions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowedToCreateApps", n => { AllowedToCreateApps = n.GetBoolValue(); } },
                {"allowedToCreateSecurityGroups", n => { AllowedToCreateSecurityGroups = n.GetBoolValue(); } },
                {"allowedToReadBitlockerKeysForOwnedDevice", n => { AllowedToReadBitlockerKeysForOwnedDevice = n.GetBoolValue(); } },
                {"allowedToReadOtherUsers", n => { AllowedToReadOtherUsers = n.GetBoolValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"permissionGrantPoliciesAssigned", n => { PermissionGrantPoliciesAssigned = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowedToCreateApps", AllowedToCreateApps);
            writer.WriteBoolValue("allowedToCreateSecurityGroups", AllowedToCreateSecurityGroups);
            writer.WriteBoolValue("allowedToReadBitlockerKeysForOwnedDevice", AllowedToReadBitlockerKeysForOwnedDevice);
            writer.WriteBoolValue("allowedToReadOtherUsers", AllowedToReadOtherUsers);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteCollectionOfPrimitiveValues<string>("permissionGrantPoliciesAssigned", PermissionGrantPoliciesAssigned);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
