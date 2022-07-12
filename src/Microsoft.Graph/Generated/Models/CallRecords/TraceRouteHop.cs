using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.CallRecords {
    public class TraceRouteHop : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The network path count of this hop that was used to compute the round-trip time.</summary>
        public int? HopCount {
            get { return BackingStore?.Get<int?>("hopCount"); }
            set { BackingStore?.Set("hopCount", value); }
        }
        /// <summary>IP address used for this hop in the network trace.</summary>
        public string IpAddress {
            get { return BackingStore?.Get<string>("ipAddress"); }
            set { BackingStore?.Set("ipAddress", value); }
        }
        /// <summary>The time from when the trace route packet was sent from the client to this hop and back to the client, denoted in [ISO 8601][] format. For example, 1 second is denoted as PT1S, where P is the duration designator, T is the time designator, and S is the second designator.</summary>
        public TimeSpan? RoundTripTime {
            get { return BackingStore?.Get<TimeSpan?>("roundTripTime"); }
            set { BackingStore?.Set("roundTripTime", value); }
        }
        /// <summary>
        /// Instantiates a new traceRouteHop and sets the default values.
        /// </summary>
        public TraceRouteHop() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TraceRouteHop CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TraceRouteHop();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"hopCount", n => { HopCount = n.GetIntValue(); } },
                {"ipAddress", n => { IpAddress = n.GetStringValue(); } },
                {"roundTripTime", n => { RoundTripTime = n.GetTimeSpanValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("hopCount", HopCount);
            writer.WriteStringValue("ipAddress", IpAddress);
            writer.WriteTimeSpanValue("roundTripTime", RoundTripTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
