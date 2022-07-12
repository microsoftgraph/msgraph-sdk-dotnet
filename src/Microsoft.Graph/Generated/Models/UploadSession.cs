using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UploadSession : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The date and time in UTC that the upload session will expire. The complete file must be uploaded before this expiration time is reached.</summary>
        public DateTimeOffset? ExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("expirationDateTime"); }
            set { BackingStore?.Set("expirationDateTime", value); }
        }
        /// <summary>When uploading files to document libraries, this is a collection of byte ranges that the server is missing for the file. These ranges are zero-indexed and of the format, &apos;{start}-{end}&apos; (e.g. &apos;0-26&apos; to indicate the first 27 bytes of the file). When uploading files as Outlook attachments, instead of a collection of ranges, this property always indicates a single value &apos;{start}&apos;, the location in the file where the next upload should begin.</summary>
        public List<string> NextExpectedRanges {
            get { return BackingStore?.Get<List<string>>("nextExpectedRanges"); }
            set { BackingStore?.Set("nextExpectedRanges", value); }
        }
        /// <summary>The URL endpoint that accepts PUT requests for byte ranges of the file.</summary>
        public string UploadUrl {
            get { return BackingStore?.Get<string>("uploadUrl"); }
            set { BackingStore?.Set("uploadUrl", value); }
        }
        /// <summary>
        /// Instantiates a new uploadSession and sets the default values.
        /// </summary>
        public UploadSession() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static UploadSession CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UploadSession();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"expirationDateTime", n => { ExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"nextExpectedRanges", n => { NextExpectedRanges = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"uploadUrl", n => { UploadUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("expirationDateTime", ExpirationDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("nextExpectedRanges", NextExpectedRanges);
            writer.WriteStringValue("uploadUrl", UploadUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
