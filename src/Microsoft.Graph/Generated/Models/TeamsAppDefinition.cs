using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public class TeamsAppDefinition : Entity, IParsable {
        /// <summary>The details of the bot specified in the Teams app manifest.</summary>
        public TeamworkBot Bot {
            get { return BackingStore?.Get<TeamworkBot>("bot"); }
            set { BackingStore?.Set("bot", value); }
        }
        /// <summary>The createdBy property</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>Verbose description of the application.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The name of the app provided by the app developer.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The lastModifiedDateTime property</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>The published status of a specific version of a Teams app. Possible values are:submitted — The specific version of the Teams app has been submitted and is under review. published  — The request to publish the specific version of the Teams app has been approved by the admin and the app is published.  rejected — The request to publish the specific version of the Teams app was rejected by the admin.</summary>
        public TeamsAppPublishingState? PublishingState {
            get { return BackingStore?.Get<TeamsAppPublishingState?>("publishingState"); }
            set { BackingStore?.Set("publishingState", value); }
        }
        /// <summary>Short description of the application.</summary>
        public string ShortDescription {
            get { return BackingStore?.Get<string>("shortDescription"); }
            set { BackingStore?.Set("shortDescription", value); }
        }
        /// <summary>The ID from the Teams app manifest.</summary>
        public string TeamsAppId {
            get { return BackingStore?.Get<string>("teamsAppId"); }
            set { BackingStore?.Set("teamsAppId", value); }
        }
        /// <summary>The version number of the application.</summary>
        public string Version {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new TeamsAppDefinition CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamsAppDefinition();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"bot", n => { Bot = n.GetObjectValue<TeamworkBot>(TeamworkBot.CreateFromDiscriminatorValue); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"publishingState", n => { PublishingState = n.GetEnumValue<TeamsAppPublishingState>(); } },
                {"shortDescription", n => { ShortDescription = n.GetStringValue(); } },
                {"teamsAppId", n => { TeamsAppId = n.GetStringValue(); } },
                {"version", n => { Version = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<TeamworkBot>("bot", Bot);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteEnumValue<TeamsAppPublishingState>("publishingState", PublishingState);
            writer.WriteStringValue("shortDescription", ShortDescription);
            writer.WriteStringValue("teamsAppId", TeamsAppId);
            writer.WriteStringValue("version", Version);
        }
    }
}
