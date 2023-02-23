using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AppManagementPolicy : PolicyBase, IParsable {
        /// <summary>The appliesTo property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DirectoryObject>? AppliesTo {
            get { return BackingStore?.Get<List<DirectoryObject>?>("appliesTo"); }
            set { BackingStore?.Set("appliesTo", value); }
        }
#nullable restore
#else
        public List<DirectoryObject> AppliesTo {
            get { return BackingStore?.Get<List<DirectoryObject>>("appliesTo"); }
            set { BackingStore?.Set("appliesTo", value); }
        }
#endif
        /// <summary>The isEnabled property</summary>
        public bool? IsEnabled {
            get { return BackingStore?.Get<bool?>("isEnabled"); }
            set { BackingStore?.Set("isEnabled", value); }
        }
        /// <summary>The restrictions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AppManagementConfiguration? Restrictions {
            get { return BackingStore?.Get<AppManagementConfiguration?>("restrictions"); }
            set { BackingStore?.Set("restrictions", value); }
        }
#nullable restore
#else
        public AppManagementConfiguration Restrictions {
            get { return BackingStore?.Get<AppManagementConfiguration>("restrictions"); }
            set { BackingStore?.Set("restrictions", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new AppManagementPolicy and sets the default values.
        /// </summary>
        public AppManagementPolicy() : base() {
            OdataType = "#microsoft.graph.appManagementPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AppManagementPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AppManagementPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appliesTo", n => { AppliesTo = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"isEnabled", n => { IsEnabled = n.GetBoolValue(); } },
                {"restrictions", n => { Restrictions = n.GetObjectValue<AppManagementConfiguration>(AppManagementConfiguration.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("appliesTo", AppliesTo);
            writer.WriteBoolValue("isEnabled", IsEnabled);
            writer.WriteObjectValue<AppManagementConfiguration>("restrictions", Restrictions);
        }
    }
}
