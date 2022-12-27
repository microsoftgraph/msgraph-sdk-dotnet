using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationTeamsAppResource : EducationResource, IParsable {
        /// <summary>URL that points to the icon of the app.</summary>
        public string AppIconWebUrl {
            get { return BackingStore?.Get<string>("appIconWebUrl"); }
            set { BackingStore?.Set("appIconWebUrl", value); }
        }
        /// <summary>Teams app ID of the application.</summary>
        public string AppId {
            get { return BackingStore?.Get<string>("appId"); }
            set { BackingStore?.Set("appId", value); }
        }
        /// <summary>URL for the app resource that will be opened by Teams.</summary>
        public string TeamsEmbeddedContentUrl {
            get { return BackingStore?.Get<string>("teamsEmbeddedContentUrl"); }
            set { BackingStore?.Set("teamsEmbeddedContentUrl", value); }
        }
        /// <summary>URL for the app resource that can be opened in the browser.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Instantiates a new EducationTeamsAppResource and sets the default values.
        /// </summary>
        public EducationTeamsAppResource() : base() {
            OdataType = "#microsoft.graph.educationTeamsAppResource";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new EducationTeamsAppResource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationTeamsAppResource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appIconWebUrl", n => { AppIconWebUrl = n.GetStringValue(); } },
                {"appId", n => { AppId = n.GetStringValue(); } },
                {"teamsEmbeddedContentUrl", n => { TeamsEmbeddedContentUrl = n.GetStringValue(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appIconWebUrl", AppIconWebUrl);
            writer.WriteStringValue("appId", AppId);
            writer.WriteStringValue("teamsEmbeddedContentUrl", TeamsEmbeddedContentUrl);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
