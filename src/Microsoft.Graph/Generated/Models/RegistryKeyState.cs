using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RegistryKeyState : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A Windows registry hive : HKEY_CURRENT_CONFIG HKEY_CURRENT_USER HKEY_LOCAL_MACHINE/SAM HKEY_LOCAL_MACHINE/Security HKEY_LOCAL_MACHINE/Software HKEY_LOCAL_MACHINE/System HKEY_USERS/.Default. Possible values are: unknown, currentConfig, currentUser, localMachineSam, localMachineSecurity, localMachineSoftware, localMachineSystem, usersDefault.</summary>
        public RegistryHive? Hive {
            get { return BackingStore?.Get<RegistryHive?>("hive"); }
            set { BackingStore?.Set("hive", value); }
        }
        /// <summary>Current (i.e. changed) registry key (excludes HIVE).</summary>
        public string Key {
            get { return BackingStore?.Get<string>("key"); }
            set { BackingStore?.Set("key", value); }
        }
        /// <summary>Previous (i.e. before changed) registry key (excludes HIVE).</summary>
        public string OldKey {
            get { return BackingStore?.Get<string>("oldKey"); }
            set { BackingStore?.Set("oldKey", value); }
        }
        /// <summary>Previous (i.e. before changed) registry key value data (contents).</summary>
        public string OldValueData {
            get { return BackingStore?.Get<string>("oldValueData"); }
            set { BackingStore?.Set("oldValueData", value); }
        }
        /// <summary>Previous (i.e. before changed) registry key value name.</summary>
        public string OldValueName {
            get { return BackingStore?.Get<string>("oldValueName"); }
            set { BackingStore?.Set("oldValueName", value); }
        }
        /// <summary>Operation that changed the registry key name and/or value. Possible values are: unknown, create, modify, delete.</summary>
        public RegistryOperation? Operation {
            get { return BackingStore?.Get<RegistryOperation?>("operation"); }
            set { BackingStore?.Set("operation", value); }
        }
        /// <summary>Process ID (PID) of the process that modified the registry key (process details will appear in the alert &apos;processes&apos; collection).</summary>
        public int? ProcessId {
            get { return BackingStore?.Get<int?>("processId"); }
            set { BackingStore?.Set("processId", value); }
        }
        /// <summary>Current (i.e. changed) registry key value data (contents).</summary>
        public string ValueData {
            get { return BackingStore?.Get<string>("valueData"); }
            set { BackingStore?.Set("valueData", value); }
        }
        /// <summary>Current (i.e. changed) registry key value name</summary>
        public string ValueName {
            get { return BackingStore?.Get<string>("valueName"); }
            set { BackingStore?.Set("valueName", value); }
        }
        /// <summary>Registry key value type REG_BINARY REG_DWORD REG_DWORD_LITTLE_ENDIAN REG_DWORD_BIG_ENDIANREG_EXPAND_SZ REG_LINK REG_MULTI_SZ REG_NONE REG_QWORD REG_QWORD_LITTLE_ENDIAN REG_SZ Possible values are: unknown, binary, dword, dwordLittleEndian, dwordBigEndian, expandSz, link, multiSz, none, qword, qwordlittleEndian, sz.</summary>
        public RegistryValueType? ValueType {
            get { return BackingStore?.Get<RegistryValueType?>("valueType"); }
            set { BackingStore?.Set("valueType", value); }
        }
        /// <summary>
        /// Instantiates a new registryKeyState and sets the default values.
        /// </summary>
        public RegistryKeyState() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RegistryKeyState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RegistryKeyState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"hive", n => { Hive = n.GetEnumValue<RegistryHive>(); } },
                {"key", n => { Key = n.GetStringValue(); } },
                {"oldKey", n => { OldKey = n.GetStringValue(); } },
                {"oldValueData", n => { OldValueData = n.GetStringValue(); } },
                {"oldValueName", n => { OldValueName = n.GetStringValue(); } },
                {"operation", n => { Operation = n.GetEnumValue<RegistryOperation>(); } },
                {"processId", n => { ProcessId = n.GetIntValue(); } },
                {"valueData", n => { ValueData = n.GetStringValue(); } },
                {"valueName", n => { ValueName = n.GetStringValue(); } },
                {"valueType", n => { ValueType = n.GetEnumValue<RegistryValueType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<RegistryHive>("hive", Hive);
            writer.WriteStringValue("key", Key);
            writer.WriteStringValue("oldKey", OldKey);
            writer.WriteStringValue("oldValueData", OldValueData);
            writer.WriteStringValue("oldValueName", OldValueName);
            writer.WriteEnumValue<RegistryOperation>("operation", Operation);
            writer.WriteIntValue("processId", ProcessId);
            writer.WriteStringValue("valueData", ValueData);
            writer.WriteStringValue("valueName", ValueName);
            writer.WriteEnumValue<RegistryValueType>("valueType", ValueType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
