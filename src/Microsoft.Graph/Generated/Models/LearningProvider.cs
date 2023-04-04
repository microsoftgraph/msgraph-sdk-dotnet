using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class LearningProvider : Entity, IParsable {
        /// <summary>The display name that appears in Viva Learning. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName {
            get { return BackingStore?.Get<string?>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#nullable restore
#else
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#endif
        /// <summary>Learning catalog items for the provider.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<LearningContent>? LearningContents {
            get { return BackingStore?.Get<List<LearningContent>?>("learningContents"); }
            set { BackingStore?.Set("learningContents", value); }
        }
#nullable restore
#else
        public List<LearningContent> LearningContents {
            get { return BackingStore?.Get<List<LearningContent>>("learningContents"); }
            set { BackingStore?.Set("learningContents", value); }
        }
#endif
        /// <summary>Authentication URL to access the courses for the provider. Optional.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LoginWebUrl {
            get { return BackingStore?.Get<string?>("loginWebUrl"); }
            set { BackingStore?.Set("loginWebUrl", value); }
        }
#nullable restore
#else
        public string LoginWebUrl {
            get { return BackingStore?.Get<string>("loginWebUrl"); }
            set { BackingStore?.Set("loginWebUrl", value); }
        }
#endif
        /// <summary>The long logo URL for the dark mode that needs to be a publicly accessible image. This image would be saved to the blob storage of Viva Learning for rendering within the Viva Learning app. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LongLogoWebUrlForDarkTheme {
            get { return BackingStore?.Get<string?>("longLogoWebUrlForDarkTheme"); }
            set { BackingStore?.Set("longLogoWebUrlForDarkTheme", value); }
        }
#nullable restore
#else
        public string LongLogoWebUrlForDarkTheme {
            get { return BackingStore?.Get<string>("longLogoWebUrlForDarkTheme"); }
            set { BackingStore?.Set("longLogoWebUrlForDarkTheme", value); }
        }
#endif
        /// <summary>The long logo URL for the light mode that needs to be a publicly accessible image. This image would be saved to the blob storage of Viva Learning for rendering within the Viva Learning app. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LongLogoWebUrlForLightTheme {
            get { return BackingStore?.Get<string?>("longLogoWebUrlForLightTheme"); }
            set { BackingStore?.Set("longLogoWebUrlForLightTheme", value); }
        }
#nullable restore
#else
        public string LongLogoWebUrlForLightTheme {
            get { return BackingStore?.Get<string>("longLogoWebUrlForLightTheme"); }
            set { BackingStore?.Set("longLogoWebUrlForLightTheme", value); }
        }
#endif
        /// <summary>The square logo URL for the dark mode that needs to be a publicly accessible image. This image would be saved to the blob storage of Viva Learning for rendering within the Viva Learning app. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SquareLogoWebUrlForDarkTheme {
            get { return BackingStore?.Get<string?>("squareLogoWebUrlForDarkTheme"); }
            set { BackingStore?.Set("squareLogoWebUrlForDarkTheme", value); }
        }
#nullable restore
#else
        public string SquareLogoWebUrlForDarkTheme {
            get { return BackingStore?.Get<string>("squareLogoWebUrlForDarkTheme"); }
            set { BackingStore?.Set("squareLogoWebUrlForDarkTheme", value); }
        }
#endif
        /// <summary>The square logo URL for the light mode that needs to be a publicly accessible image. This image would be saved to the blob storage of Viva Learning for rendering within the Viva Learning app. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SquareLogoWebUrlForLightTheme {
            get { return BackingStore?.Get<string?>("squareLogoWebUrlForLightTheme"); }
            set { BackingStore?.Set("squareLogoWebUrlForLightTheme", value); }
        }
#nullable restore
#else
        public string SquareLogoWebUrlForLightTheme {
            get { return BackingStore?.Get<string>("squareLogoWebUrlForLightTheme"); }
            set { BackingStore?.Set("squareLogoWebUrlForLightTheme", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new LearningProvider CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LearningProvider();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"learningContents", n => { LearningContents = n.GetCollectionOfObjectValues<LearningContent>(LearningContent.CreateFromDiscriminatorValue)?.ToList(); } },
                {"loginWebUrl", n => { LoginWebUrl = n.GetStringValue(); } },
                {"longLogoWebUrlForDarkTheme", n => { LongLogoWebUrlForDarkTheme = n.GetStringValue(); } },
                {"longLogoWebUrlForLightTheme", n => { LongLogoWebUrlForLightTheme = n.GetStringValue(); } },
                {"squareLogoWebUrlForDarkTheme", n => { SquareLogoWebUrlForDarkTheme = n.GetStringValue(); } },
                {"squareLogoWebUrlForLightTheme", n => { SquareLogoWebUrlForLightTheme = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<LearningContent>("learningContents", LearningContents);
            writer.WriteStringValue("loginWebUrl", LoginWebUrl);
            writer.WriteStringValue("longLogoWebUrlForDarkTheme", LongLogoWebUrlForDarkTheme);
            writer.WriteStringValue("longLogoWebUrlForLightTheme", LongLogoWebUrlForLightTheme);
            writer.WriteStringValue("squareLogoWebUrlForDarkTheme", SquareLogoWebUrlForDarkTheme);
            writer.WriteStringValue("squareLogoWebUrlForLightTheme", SquareLogoWebUrlForLightTheme);
        }
    }
}
