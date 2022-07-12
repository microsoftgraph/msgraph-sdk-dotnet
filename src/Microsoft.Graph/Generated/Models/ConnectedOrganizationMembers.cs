using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ConnectedOrganizationMembers : SubjectSet, IParsable {
        /// <summary>The ID of the connected organization in entitlement management.</summary>
        public string ConnectedOrganizationId {
            get { return BackingStore?.Get<string>("connectedOrganizationId"); }
            set { BackingStore?.Set("connectedOrganizationId", value); }
        }
        /// <summary>The name of the connected organization. Read only.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ConnectedOrganizationMembers CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConnectedOrganizationMembers();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"connectedOrganizationId", n => { ConnectedOrganizationId = n.GetStringValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("connectedOrganizationId", ConnectedOrganizationId);
            writer.WriteStringValue("description", Description);
        }
    }
}
