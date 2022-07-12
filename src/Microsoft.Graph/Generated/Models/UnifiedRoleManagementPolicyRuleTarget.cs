using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UnifiedRoleManagementPolicyRuleTarget : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The type of caller that&apos;s the target of the policy rule. Allowed values are: None, Admin, EndUser.</summary>
        public string Caller {
            get { return BackingStore?.Get<string>("caller"); }
            set { BackingStore?.Set("caller", value); }
        }
        /// <summary>The list of role settings that are enforced and cannot be overridden by child scopes. Use All for all settings.</summary>
        public List<string> EnforcedSettings {
            get { return BackingStore?.Get<List<string>>("enforcedSettings"); }
            set { BackingStore?.Set("enforcedSettings", value); }
        }
        /// <summary>The list of role settings that can be inherited by child scopes. Use All for all settings.</summary>
        public List<string> InheritableSettings {
            get { return BackingStore?.Get<List<string>>("inheritableSettings"); }
            set { BackingStore?.Set("inheritableSettings", value); }
        }
        /// <summary>The role assignment type that&apos;s the target of policy rule. Allowed values are: Eligibility, Assignment.</summary>
        public string Level {
            get { return BackingStore?.Get<string>("level"); }
            set { BackingStore?.Set("level", value); }
        }
        /// <summary>The role management operations that are the target of the policy rule. Allowed values are: All, Activate, Deactivate, Assign, Update, Remove, Extend, Renew.</summary>
        public List<string> Operations {
            get { return BackingStore?.Get<List<string>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>The targetObjects property</summary>
        public List<DirectoryObject> TargetObjects {
            get { return BackingStore?.Get<List<DirectoryObject>>("targetObjects"); }
            set { BackingStore?.Set("targetObjects", value); }
        }
        /// <summary>
        /// Instantiates a new unifiedRoleManagementPolicyRuleTarget and sets the default values.
        /// </summary>
        public UnifiedRoleManagementPolicyRuleTarget() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static UnifiedRoleManagementPolicyRuleTarget CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UnifiedRoleManagementPolicyRuleTarget();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"caller", n => { Caller = n.GetStringValue(); } },
                {"enforcedSettings", n => { EnforcedSettings = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"inheritableSettings", n => { InheritableSettings = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"level", n => { Level = n.GetStringValue(); } },
                {"operations", n => { Operations = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"targetObjects", n => { TargetObjects = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("caller", Caller);
            writer.WriteCollectionOfPrimitiveValues<string>("enforcedSettings", EnforcedSettings);
            writer.WriteCollectionOfPrimitiveValues<string>("inheritableSettings", InheritableSettings);
            writer.WriteStringValue("level", Level);
            writer.WriteCollectionOfPrimitiveValues<string>("operations", Operations);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("targetObjects", TargetObjects);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
