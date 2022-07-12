using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ServiceHealth : Entity, IParsable {
        /// <summary>A collection of issues that happened on the service, with detailed information for each issue.</summary>
        public List<ServiceHealthIssue> Issues {
            get { return BackingStore?.Get<List<ServiceHealthIssue>>("issues"); }
            set { BackingStore?.Set("issues", value); }
        }
        /// <summary>The service name. Use the list healthOverviews operation to get exact string names for services subscribed by the tenant.</summary>
        public string Service {
            get { return BackingStore?.Get<string>("service"); }
            set { BackingStore?.Set("service", value); }
        }
        /// <summary>The status property</summary>
        public ServiceHealthStatus? Status {
            get { return BackingStore?.Get<ServiceHealthStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ServiceHealth CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ServiceHealth();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"issues", n => { Issues = n.GetCollectionOfObjectValues<ServiceHealthIssue>(ServiceHealthIssue.CreateFromDiscriminatorValue).ToList(); } },
                {"service", n => { Service = n.GetStringValue(); } },
                {"status", n => { Status = n.GetEnumValue<ServiceHealthStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ServiceHealthIssue>("issues", Issues);
            writer.WriteStringValue("service", Service);
            writer.WriteEnumValue<ServiceHealthStatus>("status", Status);
        }
    }
}
