using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SignInStatus : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Provides additional details on the sign-in activity</summary>
        public string AdditionalDetails {
            get { return BackingStore?.Get<string>("additionalDetails"); }
            set { BackingStore?.Set("additionalDetails", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Provides the 5-6 digit error code that&apos;s generated during a sign-in failure. Check out the list of error codes and messages.</summary>
        public int? ErrorCode {
            get { return BackingStore?.Get<int?>("errorCode"); }
            set { BackingStore?.Set("errorCode", value); }
        }
        /// <summary>Provides the error message or the reason for failure for the corresponding sign-in activity. Check out the list of error codes and messages.</summary>
        public string FailureReason {
            get { return BackingStore?.Get<string>("failureReason"); }
            set { BackingStore?.Set("failureReason", value); }
        }
        /// <summary>
        /// Instantiates a new signInStatus and sets the default values.
        /// </summary>
        public SignInStatus() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SignInStatus CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SignInStatus();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"additionalDetails", n => { AdditionalDetails = n.GetStringValue(); } },
                {"errorCode", n => { ErrorCode = n.GetIntValue(); } },
                {"failureReason", n => { FailureReason = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("additionalDetails", AdditionalDetails);
            writer.WriteIntValue("errorCode", ErrorCode);
            writer.WriteStringValue("failureReason", FailureReason);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
