using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessPackageAnswer : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The answeredQuestion property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AccessPackageQuestion? AnsweredQuestion {
            get { return BackingStore?.Get<AccessPackageQuestion?>("answeredQuestion"); }
            set { BackingStore?.Set("answeredQuestion", value); }
        }
#nullable restore
#else
        public AccessPackageQuestion AnsweredQuestion {
            get { return BackingStore?.Get<AccessPackageQuestion>("answeredQuestion"); }
            set { BackingStore?.Set("answeredQuestion", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The localized display value shown to the requestor and approvers.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayValue {
            get { return BackingStore?.Get<string?>("displayValue"); }
            set { BackingStore?.Set("displayValue", value); }
        }
#nullable restore
#else
        public string DisplayValue {
            get { return BackingStore?.Get<string>("displayValue"); }
            set { BackingStore?.Set("displayValue", value); }
        }
#endif
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new accessPackageAnswer and sets the default values.
        /// </summary>
        public AccessPackageAnswer() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AccessPackageAnswer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.accessPackageAnswerString" => new AccessPackageAnswerString(),
                _ => new AccessPackageAnswer(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"answeredQuestion", n => { AnsweredQuestion = n.GetObjectValue<AccessPackageQuestion>(AccessPackageQuestion.CreateFromDiscriminatorValue); } },
                {"displayValue", n => { DisplayValue = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AccessPackageQuestion>("answeredQuestion", AnsweredQuestion);
            writer.WriteStringValue("displayValue", DisplayValue);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
