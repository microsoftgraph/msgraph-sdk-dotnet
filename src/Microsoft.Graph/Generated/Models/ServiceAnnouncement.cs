using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ServiceAnnouncement : Entity, IParsable {
        /// <summary>A collection of service health information for tenant. This property is a contained navigation property, it is nullable and readonly.</summary>
        public List<ServiceHealth> HealthOverviews {
            get { return BackingStore?.Get<List<ServiceHealth>>("healthOverviews"); }
            set { BackingStore?.Set("healthOverviews", value); }
        }
        /// <summary>A collection of service issues for tenant. This property is a contained navigation property, it is nullable and readonly.</summary>
        public List<ServiceHealthIssue> Issues {
            get { return BackingStore?.Get<List<ServiceHealthIssue>>("issues"); }
            set { BackingStore?.Set("issues", value); }
        }
        /// <summary>A collection of service messages for tenant. This property is a contained navigation property, it is nullable and readonly.</summary>
        public List<ServiceUpdateMessage> Messages {
            get { return BackingStore?.Get<List<ServiceUpdateMessage>>("messages"); }
            set { BackingStore?.Set("messages", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ServiceAnnouncement CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ServiceAnnouncement();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"healthOverviews", n => { HealthOverviews = n.GetCollectionOfObjectValues<ServiceHealth>(ServiceHealth.CreateFromDiscriminatorValue).ToList(); } },
                {"issues", n => { Issues = n.GetCollectionOfObjectValues<ServiceHealthIssue>(ServiceHealthIssue.CreateFromDiscriminatorValue).ToList(); } },
                {"messages", n => { Messages = n.GetCollectionOfObjectValues<ServiceUpdateMessage>(ServiceUpdateMessage.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ServiceHealth>("healthOverviews", HealthOverviews);
            writer.WriteCollectionOfObjectValues<ServiceHealthIssue>("issues", Issues);
            writer.WriteCollectionOfObjectValues<ServiceUpdateMessage>("messages", Messages);
        }
    }
}
