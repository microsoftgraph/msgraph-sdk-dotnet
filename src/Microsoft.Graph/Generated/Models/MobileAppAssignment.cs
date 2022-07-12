using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>A class containing the properties used for Group Assignment of a Mobile App.</summary>
    public class MobileAppAssignment : Entity, IParsable {
        /// <summary>Possible values for the install intent chosen by the admin.</summary>
        public InstallIntent? Intent {
            get { return BackingStore?.Get<InstallIntent?>("intent"); }
            set { BackingStore?.Set("intent", value); }
        }
        /// <summary>The settings for target assignment defined by the admin.</summary>
        public MobileAppAssignmentSettings Settings {
            get { return BackingStore?.Get<MobileAppAssignmentSettings>("settings"); }
            set { BackingStore?.Set("settings", value); }
        }
        /// <summary>The target group assignment defined by the admin.</summary>
        public DeviceAndAppManagementAssignmentTarget Target {
            get { return BackingStore?.Get<DeviceAndAppManagementAssignmentTarget>("target"); }
            set { BackingStore?.Set("target", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MobileAppAssignment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MobileAppAssignment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"intent", n => { Intent = n.GetEnumValue<InstallIntent>(); } },
                {"settings", n => { Settings = n.GetObjectValue<MobileAppAssignmentSettings>(MobileAppAssignmentSettings.CreateFromDiscriminatorValue); } },
                {"target", n => { Target = n.GetObjectValue<DeviceAndAppManagementAssignmentTarget>(DeviceAndAppManagementAssignmentTarget.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<InstallIntent>("intent", Intent);
            writer.WriteObjectValue<MobileAppAssignmentSettings>("settings", Settings);
            writer.WriteObjectValue<DeviceAndAppManagementAssignmentTarget>("target", Target);
        }
    }
}
