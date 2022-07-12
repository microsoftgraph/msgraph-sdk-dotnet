using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CrossTenantAccessPolicyB2BSetting : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The list of applications targeted with your cross-tenant access policy.</summary>
        public CrossTenantAccessPolicyTargetConfiguration Applications {
            get { return BackingStore?.Get<CrossTenantAccessPolicyTargetConfiguration>("applications"); }
            set { BackingStore?.Set("applications", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The list of users and groups targeted with your cross-tenant access policy.</summary>
        public CrossTenantAccessPolicyTargetConfiguration UsersAndGroups {
            get { return BackingStore?.Get<CrossTenantAccessPolicyTargetConfiguration>("usersAndGroups"); }
            set { BackingStore?.Set("usersAndGroups", value); }
        }
        /// <summary>
        /// Instantiates a new crossTenantAccessPolicyB2BSetting and sets the default values.
        /// </summary>
        public CrossTenantAccessPolicyB2BSetting() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CrossTenantAccessPolicyB2BSetting CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CrossTenantAccessPolicyB2BSetting();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"applications", n => { Applications = n.GetObjectValue<CrossTenantAccessPolicyTargetConfiguration>(CrossTenantAccessPolicyTargetConfiguration.CreateFromDiscriminatorValue); } },
                {"usersAndGroups", n => { UsersAndGroups = n.GetObjectValue<CrossTenantAccessPolicyTargetConfiguration>(CrossTenantAccessPolicyTargetConfiguration.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<CrossTenantAccessPolicyTargetConfiguration>("applications", Applications);
            writer.WriteObjectValue<CrossTenantAccessPolicyTargetConfiguration>("usersAndGroups", UsersAndGroups);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
