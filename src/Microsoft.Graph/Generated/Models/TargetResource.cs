using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TargetResource : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates the visible name defined for the resource. Typically specified when the resource is created.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>When type is set to Group, this indicates the group type.  Possible values are: unifiedGroups, azureAD, and unknownFutureValue</summary>
        public Microsoft.Graph.Models.GroupType? GroupType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.GroupType?>("groupType"); }
            set { BackingStore?.Set("groupType", value); }
        }
        /// <summary>Indicates the unique ID of the resource.</summary>
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>Indicates name, old value and new value of each attribute that changed. Property values depend on the operation type.</summary>
        public List<ModifiedProperty> ModifiedProperties {
            get { return BackingStore?.Get<List<ModifiedProperty>>("modifiedProperties"); }
            set { BackingStore?.Set("modifiedProperties", value); }
        }
        /// <summary>Describes the resource type.  Example values include Application, Group, ServicePrincipal, and User.</summary>
        public string Type {
            get { return BackingStore?.Get<string>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>When type is set to User, this includes the user name that initiated the action; null for other types.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Instantiates a new targetResource and sets the default values.
        /// </summary>
        public TargetResource() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TargetResource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TargetResource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"groupType", n => { GroupType = n.GetEnumValue<GroupType>(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"modifiedProperties", n => { ModifiedProperties = n.GetCollectionOfObjectValues<ModifiedProperty>(ModifiedProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"type", n => { Type = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteEnumValue<GroupType>("groupType", GroupType);
            writer.WriteStringValue("id", Id);
            writer.WriteCollectionOfObjectValues<ModifiedProperty>("modifiedProperties", ModifiedProperties);
            writer.WriteStringValue("type", Type);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
