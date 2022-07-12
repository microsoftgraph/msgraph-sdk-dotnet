using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DocumentSet : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Content types allowed in document set.</summary>
        public List<ContentTypeInfo> AllowedContentTypes {
            get { return BackingStore?.Get<List<ContentTypeInfo>>("allowedContentTypes"); }
            set { BackingStore?.Set("allowedContentTypes", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Default contents of document set.</summary>
        public List<DocumentSetContent> DefaultContents {
            get { return BackingStore?.Get<List<DocumentSetContent>>("defaultContents"); }
            set { BackingStore?.Set("defaultContents", value); }
        }
        /// <summary>Indicates whether to add the name of the document set to each file name.</summary>
        public bool? PropagateWelcomePageChanges {
            get { return BackingStore?.Get<bool?>("propagateWelcomePageChanges"); }
            set { BackingStore?.Set("propagateWelcomePageChanges", value); }
        }
        /// <summary>The sharedColumns property</summary>
        public List<ColumnDefinition> SharedColumns {
            get { return BackingStore?.Get<List<ColumnDefinition>>("sharedColumns"); }
            set { BackingStore?.Set("sharedColumns", value); }
        }
        /// <summary>Add the name of the Document Set to each file name.</summary>
        public bool? ShouldPrefixNameToFile {
            get { return BackingStore?.Get<bool?>("shouldPrefixNameToFile"); }
            set { BackingStore?.Set("shouldPrefixNameToFile", value); }
        }
        /// <summary>The welcomePageColumns property</summary>
        public List<ColumnDefinition> WelcomePageColumns {
            get { return BackingStore?.Get<List<ColumnDefinition>>("welcomePageColumns"); }
            set { BackingStore?.Set("welcomePageColumns", value); }
        }
        /// <summary>Welcome page absolute URL.</summary>
        public string WelcomePageUrl {
            get { return BackingStore?.Get<string>("welcomePageUrl"); }
            set { BackingStore?.Set("welcomePageUrl", value); }
        }
        /// <summary>
        /// Instantiates a new documentSet and sets the default values.
        /// </summary>
        public DocumentSet() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DocumentSet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DocumentSet();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowedContentTypes", n => { AllowedContentTypes = n.GetCollectionOfObjectValues<ContentTypeInfo>(ContentTypeInfo.CreateFromDiscriminatorValue).ToList(); } },
                {"defaultContents", n => { DefaultContents = n.GetCollectionOfObjectValues<DocumentSetContent>(DocumentSetContent.CreateFromDiscriminatorValue).ToList(); } },
                {"propagateWelcomePageChanges", n => { PropagateWelcomePageChanges = n.GetBoolValue(); } },
                {"sharedColumns", n => { SharedColumns = n.GetCollectionOfObjectValues<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue).ToList(); } },
                {"shouldPrefixNameToFile", n => { ShouldPrefixNameToFile = n.GetBoolValue(); } },
                {"welcomePageColumns", n => { WelcomePageColumns = n.GetCollectionOfObjectValues<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue).ToList(); } },
                {"welcomePageUrl", n => { WelcomePageUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ContentTypeInfo>("allowedContentTypes", AllowedContentTypes);
            writer.WriteCollectionOfObjectValues<DocumentSetContent>("defaultContents", DefaultContents);
            writer.WriteBoolValue("propagateWelcomePageChanges", PropagateWelcomePageChanges);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("sharedColumns", SharedColumns);
            writer.WriteBoolValue("shouldPrefixNameToFile", ShouldPrefixNameToFile);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("welcomePageColumns", WelcomePageColumns);
            writer.WriteStringValue("welcomePageUrl", WelcomePageUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
