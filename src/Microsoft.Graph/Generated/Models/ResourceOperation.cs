using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Describes the resourceOperation resource (entity) of the Microsoft Graph API (REST), which supports Intune workflows related to role-based access control (RBAC).</summary>
    public class ResourceOperation : Entity, IParsable {
        /// <summary>Type of action this operation is going to perform. The actionName should be concise and limited to as few words as possible.</summary>
        public string ActionName {
            get { return BackingStore?.Get<string>("actionName"); }
            set { BackingStore?.Set("actionName", value); }
        }
        /// <summary>Description of the resource operation. The description is used in mouse-over text for the operation when shown in the Azure Portal.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Name of the Resource this operation is performed on.</summary>
        public string ResourceName {
            get { return BackingStore?.Get<string>("resourceName"); }
            set { BackingStore?.Set("resourceName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ResourceOperation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ResourceOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"actionName", n => { ActionName = n.GetStringValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"resourceName", n => { ResourceName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("actionName", ActionName);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("resourceName", ResourceName);
        }
    }
}
