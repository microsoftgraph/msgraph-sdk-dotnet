using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
    public class Participant : Entity, IParsable {
        /// <summary>The info property</summary>
        public ParticipantInfo Info {
            get { return BackingStore?.Get<ParticipantInfo>("info"); }
            set { BackingStore?.Set("info", value); }
        }
        /// <summary>true if the participant is in lobby.</summary>
        public bool? IsInLobby {
            get { return BackingStore?.Get<bool?>("isInLobby"); }
            set { BackingStore?.Set("isInLobby", value); }
        }
        /// <summary>true if the participant is muted (client or server muted).</summary>
        public bool? IsMuted {
            get { return BackingStore?.Get<bool?>("isMuted"); }
            set { BackingStore?.Set("isMuted", value); }
        }
        /// <summary>The list of media streams.</summary>
        public List<MediaStream> MediaStreams {
            get { return BackingStore?.Get<List<MediaStream>>("mediaStreams"); }
            set { BackingStore?.Set("mediaStreams", value); }
        }
        /// <summary>A blob of data provided by the participant in the roster.</summary>
        public string Metadata {
            get { return BackingStore?.Get<string>("metadata"); }
            set { BackingStore?.Set("metadata", value); }
        }
        /// <summary>Information about whether the participant has recording capability.</summary>
        public Microsoft.Graph.Models.RecordingInfo RecordingInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RecordingInfo>("recordingInfo"); }
            set { BackingStore?.Set("recordingInfo", value); }
        }
        /// <summary>
        /// Instantiates a new participant and sets the default values.
        /// </summary>
        public Participant() : base() {
            OdataType = "#microsoft.graph.participant";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Participant CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Participant();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"info", n => { Info = n.GetObjectValue<ParticipantInfo>(ParticipantInfo.CreateFromDiscriminatorValue); } },
                {"isInLobby", n => { IsInLobby = n.GetBoolValue(); } },
                {"isMuted", n => { IsMuted = n.GetBoolValue(); } },
                {"mediaStreams", n => { MediaStreams = n.GetCollectionOfObjectValues<MediaStream>(MediaStream.CreateFromDiscriminatorValue)?.ToList(); } },
                {"metadata", n => { Metadata = n.GetStringValue(); } },
                {"recordingInfo", n => { RecordingInfo = n.GetObjectValue<Microsoft.Graph.Models.RecordingInfo>(Microsoft.Graph.Models.RecordingInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ParticipantInfo>("info", Info);
            writer.WriteBoolValue("isInLobby", IsInLobby);
            writer.WriteBoolValue("isMuted", IsMuted);
            writer.WriteCollectionOfObjectValues<MediaStream>("mediaStreams", MediaStreams);
            writer.WriteStringValue("metadata", Metadata);
            writer.WriteObjectValue<Microsoft.Graph.Models.RecordingInfo>("recordingInfo", RecordingInfo);
        }
    }
}
