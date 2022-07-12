using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OnPremisesExtensionAttributes : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>First customizable extension attribute.</summary>
        public string ExtensionAttribute1 {
            get { return BackingStore?.Get<string>("extensionAttribute1"); }
            set { BackingStore?.Set("extensionAttribute1", value); }
        }
        /// <summary>Tenth customizable extension attribute.</summary>
        public string ExtensionAttribute10 {
            get { return BackingStore?.Get<string>("extensionAttribute10"); }
            set { BackingStore?.Set("extensionAttribute10", value); }
        }
        /// <summary>Eleventh customizable extension attribute.</summary>
        public string ExtensionAttribute11 {
            get { return BackingStore?.Get<string>("extensionAttribute11"); }
            set { BackingStore?.Set("extensionAttribute11", value); }
        }
        /// <summary>Twelfth customizable extension attribute.</summary>
        public string ExtensionAttribute12 {
            get { return BackingStore?.Get<string>("extensionAttribute12"); }
            set { BackingStore?.Set("extensionAttribute12", value); }
        }
        /// <summary>Thirteenth customizable extension attribute.</summary>
        public string ExtensionAttribute13 {
            get { return BackingStore?.Get<string>("extensionAttribute13"); }
            set { BackingStore?.Set("extensionAttribute13", value); }
        }
        /// <summary>Fourteenth customizable extension attribute.</summary>
        public string ExtensionAttribute14 {
            get { return BackingStore?.Get<string>("extensionAttribute14"); }
            set { BackingStore?.Set("extensionAttribute14", value); }
        }
        /// <summary>Fifteenth customizable extension attribute.</summary>
        public string ExtensionAttribute15 {
            get { return BackingStore?.Get<string>("extensionAttribute15"); }
            set { BackingStore?.Set("extensionAttribute15", value); }
        }
        /// <summary>Second customizable extension attribute.</summary>
        public string ExtensionAttribute2 {
            get { return BackingStore?.Get<string>("extensionAttribute2"); }
            set { BackingStore?.Set("extensionAttribute2", value); }
        }
        /// <summary>Third customizable extension attribute.</summary>
        public string ExtensionAttribute3 {
            get { return BackingStore?.Get<string>("extensionAttribute3"); }
            set { BackingStore?.Set("extensionAttribute3", value); }
        }
        /// <summary>Fourth customizable extension attribute.</summary>
        public string ExtensionAttribute4 {
            get { return BackingStore?.Get<string>("extensionAttribute4"); }
            set { BackingStore?.Set("extensionAttribute4", value); }
        }
        /// <summary>Fifth customizable extension attribute.</summary>
        public string ExtensionAttribute5 {
            get { return BackingStore?.Get<string>("extensionAttribute5"); }
            set { BackingStore?.Set("extensionAttribute5", value); }
        }
        /// <summary>Sixth customizable extension attribute.</summary>
        public string ExtensionAttribute6 {
            get { return BackingStore?.Get<string>("extensionAttribute6"); }
            set { BackingStore?.Set("extensionAttribute6", value); }
        }
        /// <summary>Seventh customizable extension attribute.</summary>
        public string ExtensionAttribute7 {
            get { return BackingStore?.Get<string>("extensionAttribute7"); }
            set { BackingStore?.Set("extensionAttribute7", value); }
        }
        /// <summary>Eighth customizable extension attribute.</summary>
        public string ExtensionAttribute8 {
            get { return BackingStore?.Get<string>("extensionAttribute8"); }
            set { BackingStore?.Set("extensionAttribute8", value); }
        }
        /// <summary>Ninth customizable extension attribute.</summary>
        public string ExtensionAttribute9 {
            get { return BackingStore?.Get<string>("extensionAttribute9"); }
            set { BackingStore?.Set("extensionAttribute9", value); }
        }
        /// <summary>
        /// Instantiates a new onPremisesExtensionAttributes and sets the default values.
        /// </summary>
        public OnPremisesExtensionAttributes() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OnPremisesExtensionAttributes CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnPremisesExtensionAttributes();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"extensionAttribute1", n => { ExtensionAttribute1 = n.GetStringValue(); } },
                {"extensionAttribute10", n => { ExtensionAttribute10 = n.GetStringValue(); } },
                {"extensionAttribute11", n => { ExtensionAttribute11 = n.GetStringValue(); } },
                {"extensionAttribute12", n => { ExtensionAttribute12 = n.GetStringValue(); } },
                {"extensionAttribute13", n => { ExtensionAttribute13 = n.GetStringValue(); } },
                {"extensionAttribute14", n => { ExtensionAttribute14 = n.GetStringValue(); } },
                {"extensionAttribute15", n => { ExtensionAttribute15 = n.GetStringValue(); } },
                {"extensionAttribute2", n => { ExtensionAttribute2 = n.GetStringValue(); } },
                {"extensionAttribute3", n => { ExtensionAttribute3 = n.GetStringValue(); } },
                {"extensionAttribute4", n => { ExtensionAttribute4 = n.GetStringValue(); } },
                {"extensionAttribute5", n => { ExtensionAttribute5 = n.GetStringValue(); } },
                {"extensionAttribute6", n => { ExtensionAttribute6 = n.GetStringValue(); } },
                {"extensionAttribute7", n => { ExtensionAttribute7 = n.GetStringValue(); } },
                {"extensionAttribute8", n => { ExtensionAttribute8 = n.GetStringValue(); } },
                {"extensionAttribute9", n => { ExtensionAttribute9 = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("extensionAttribute1", ExtensionAttribute1);
            writer.WriteStringValue("extensionAttribute10", ExtensionAttribute10);
            writer.WriteStringValue("extensionAttribute11", ExtensionAttribute11);
            writer.WriteStringValue("extensionAttribute12", ExtensionAttribute12);
            writer.WriteStringValue("extensionAttribute13", ExtensionAttribute13);
            writer.WriteStringValue("extensionAttribute14", ExtensionAttribute14);
            writer.WriteStringValue("extensionAttribute15", ExtensionAttribute15);
            writer.WriteStringValue("extensionAttribute2", ExtensionAttribute2);
            writer.WriteStringValue("extensionAttribute3", ExtensionAttribute3);
            writer.WriteStringValue("extensionAttribute4", ExtensionAttribute4);
            writer.WriteStringValue("extensionAttribute5", ExtensionAttribute5);
            writer.WriteStringValue("extensionAttribute6", ExtensionAttribute6);
            writer.WriteStringValue("extensionAttribute7", ExtensionAttribute7);
            writer.WriteStringValue("extensionAttribute8", ExtensionAttribute8);
            writer.WriteStringValue("extensionAttribute9", ExtensionAttribute9);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
