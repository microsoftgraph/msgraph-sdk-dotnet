// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class WindowsSetting : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>A collection of setting values for a given windowsSetting.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.WindowsSettingInstance>? Instances
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.WindowsSettingInstance>?>("instances"); }
            set { BackingStore?.Set("instances", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.WindowsSettingInstance> Instances
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.WindowsSettingInstance>>("instances"); }
            set { BackingStore?.Set("instances", value); }
        }
#endif
        /// <summary>The type of setting payloads contained in the instances navigation property.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PayloadType
        {
            get { return BackingStore?.Get<string?>("payloadType"); }
            set { BackingStore?.Set("payloadType", value); }
        }
#nullable restore
#else
        public string PayloadType
        {
            get { return BackingStore?.Get<string>("payloadType"); }
            set { BackingStore?.Set("payloadType", value); }
        }
#endif
        /// <summary>The settingType property</summary>
        public global::Microsoft.Graph.Models.WindowsSettingType? SettingType
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.WindowsSettingType?>("settingType"); }
            set { BackingStore?.Set("settingType", value); }
        }
        /// <summary>A unique identifier for the device the setting might belong to if it is of the settingType backup.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? WindowsDeviceId
        {
            get { return BackingStore?.Get<string?>("windowsDeviceId"); }
            set { BackingStore?.Set("windowsDeviceId", value); }
        }
#nullable restore
#else
        public string WindowsDeviceId
        {
            get { return BackingStore?.Get<string>("windowsDeviceId"); }
            set { BackingStore?.Set("windowsDeviceId", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.WindowsSetting"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.WindowsSetting CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.WindowsSetting();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "instances", n => { Instances = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.WindowsSettingInstance>(global::Microsoft.Graph.Models.WindowsSettingInstance.CreateFromDiscriminatorValue)?.AsList(); } },
                { "payloadType", n => { PayloadType = n.GetStringValue(); } },
                { "settingType", n => { SettingType = n.GetEnumValue<global::Microsoft.Graph.Models.WindowsSettingType>(); } },
                { "windowsDeviceId", n => { WindowsDeviceId = n.GetStringValue(); } },
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
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.WindowsSettingInstance>("instances", Instances);
            writer.WriteStringValue("payloadType", PayloadType);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.WindowsSettingType>("settingType", SettingType);
            writer.WriteStringValue("windowsDeviceId", WindowsDeviceId);
        }
    }
}
#pragma warning restore CS0618
