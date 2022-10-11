using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class UserFlowLanguageConfiguration : Entity, IParsable {
        /// <summary>Collection of pages with the default content to display in a user flow for a specified language. This collection does not allow any kind of modification.</summary>
        public List<UserFlowLanguagePage> DefaultPages {
            get { return BackingStore?.Get<List<UserFlowLanguagePage>>("defaultPages"); }
            set { BackingStore?.Set("defaultPages", value); }
        }
        /// <summary>The language name to display. This property is read-only.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Indicates whether the language is enabled within the user flow.</summary>
        public bool? IsEnabled {
            get { return BackingStore?.Get<bool?>("isEnabled"); }
            set { BackingStore?.Set("isEnabled", value); }
        }
        /// <summary>Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).</summary>
        public List<UserFlowLanguagePage> OverridesPages {
            get { return BackingStore?.Get<List<UserFlowLanguagePage>>("overridesPages"); }
            set { BackingStore?.Set("overridesPages", value); }
        }
        /// <summary>
        /// Instantiates a new userFlowLanguageConfiguration and sets the default values.
        /// </summary>
        public UserFlowLanguageConfiguration() : base() {
            OdataType = "#microsoft.graph.userFlowLanguageConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UserFlowLanguageConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserFlowLanguageConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"defaultPages", n => { DefaultPages = n.GetCollectionOfObjectValues<UserFlowLanguagePage>(UserFlowLanguagePage.CreateFromDiscriminatorValue)?.ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isEnabled", n => { IsEnabled = n.GetBoolValue(); } },
                {"overridesPages", n => { OverridesPages = n.GetCollectionOfObjectValues<UserFlowLanguagePage>(UserFlowLanguagePage.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<UserFlowLanguagePage>("defaultPages", DefaultPages);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isEnabled", IsEnabled);
            writer.WriteCollectionOfObjectValues<UserFlowLanguagePage>("overridesPages", OverridesPages);
        }
    }
}
