using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Shared : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The identity of the owner of the shared item. Read-only.</summary>
        public IdentitySet Owner {
            get { return BackingStore?.Get<IdentitySet>("owner"); }
            set { BackingStore?.Set("owner", value); }
        }
        /// <summary>Indicates the scope of how the item is shared: anonymous, organization, or users. Read-only.</summary>
        public string Scope {
            get { return BackingStore?.Get<string>("scope"); }
            set { BackingStore?.Set("scope", value); }
        }
        /// <summary>The identity of the user who shared the item. Read-only.</summary>
        public IdentitySet SharedBy {
            get { return BackingStore?.Get<IdentitySet>("sharedBy"); }
            set { BackingStore?.Set("sharedBy", value); }
        }
        /// <summary>The UTC date and time when the item was shared. Read-only.</summary>
        public DateTimeOffset? SharedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("sharedDateTime"); }
            set { BackingStore?.Set("sharedDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new shared and sets the default values.
        /// </summary>
        public Shared() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Shared CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Shared();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"owner", n => { Owner = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"scope", n => { Scope = n.GetStringValue(); } },
                {"sharedBy", n => { SharedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"sharedDateTime", n => { SharedDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IdentitySet>("owner", Owner);
            writer.WriteStringValue("scope", Scope);
            writer.WriteObjectValue<IdentitySet>("sharedBy", SharedBy);
            writer.WriteDateTimeOffsetValue("sharedDateTime", SharedDateTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
