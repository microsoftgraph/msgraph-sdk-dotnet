using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Hashes : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The CRC32 value of the file (if available). Read-only.</summary>
        public string Crc32Hash {
            get { return BackingStore?.Get<string>("crc32Hash"); }
            set { BackingStore?.Set("crc32Hash", value); }
        }
        /// <summary>A proprietary hash of the file that can be used to determine if the contents of the file have changed (if available). Read-only.</summary>
        public string QuickXorHash {
            get { return BackingStore?.Get<string>("quickXorHash"); }
            set { BackingStore?.Set("quickXorHash", value); }
        }
        /// <summary>SHA1 hash for the contents of the file (if available). Read-only.</summary>
        public string Sha1Hash {
            get { return BackingStore?.Get<string>("sha1Hash"); }
            set { BackingStore?.Set("sha1Hash", value); }
        }
        /// <summary>SHA256 hash for the contents of the file (if available). Read-only.</summary>
        public string Sha256Hash {
            get { return BackingStore?.Get<string>("sha256Hash"); }
            set { BackingStore?.Set("sha256Hash", value); }
        }
        /// <summary>
        /// Instantiates a new hashes and sets the default values.
        /// </summary>
        public Hashes() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Hashes CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Hashes();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"crc32Hash", n => { Crc32Hash = n.GetStringValue(); } },
                {"quickXorHash", n => { QuickXorHash = n.GetStringValue(); } },
                {"sha1Hash", n => { Sha1Hash = n.GetStringValue(); } },
                {"sha256Hash", n => { Sha256Hash = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("crc32Hash", Crc32Hash);
            writer.WriteStringValue("quickXorHash", QuickXorHash);
            writer.WriteStringValue("sha1Hash", Sha1Hash);
            writer.WriteStringValue("sha256Hash", Sha256Hash);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
