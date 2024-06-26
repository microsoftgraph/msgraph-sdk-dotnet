// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class VirtualEventSession : Microsoft.Graph.Models.OnlineMeetingBase, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The virtual event session end time.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.DateTimeTimeZone? EndDateTime
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DateTimeTimeZone?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.DateTimeTimeZone EndDateTime
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DateTimeTimeZone>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#endif
        /// <summary>The virtual event session start time.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.DateTimeTimeZone? StartDateTime
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DateTimeTimeZone?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.DateTimeTimeZone StartDateTime
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DateTimeTimeZone>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="Microsoft.Graph.Models.VirtualEventSession"/> and sets the default values.
        /// </summary>
        public VirtualEventSession() : base()
        {
            OdataType = "#microsoft.graph.virtualEventSession";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.VirtualEventSession"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.VirtualEventSession CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.VirtualEventSession();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "endDateTime", n => { EndDateTime = n.GetObjectValue<Microsoft.Graph.Models.DateTimeTimeZone>(Microsoft.Graph.Models.DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                { "startDateTime", n => { StartDateTime = n.GetObjectValue<Microsoft.Graph.Models.DateTimeTimeZone>(Microsoft.Graph.Models.DateTimeTimeZone.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.DateTimeTimeZone>("endDateTime", EndDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.DateTimeTimeZone>("startDateTime", StartDateTime);
        }
    }
}
