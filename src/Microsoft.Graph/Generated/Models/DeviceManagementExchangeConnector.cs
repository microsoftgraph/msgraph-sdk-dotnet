using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Entity which represents a connection to an Exchange environment.</summary>
    public class DeviceManagementExchangeConnector : Entity, IParsable {
        /// <summary>The name of the server hosting the Exchange Connector.</summary>
        public string ConnectorServerName {
            get { return BackingStore?.Get<string>("connectorServerName"); }
            set { BackingStore?.Set("connectorServerName", value); }
        }
        /// <summary>An alias assigned to the Exchange server</summary>
        public string ExchangeAlias {
            get { return BackingStore?.Get<string>("exchangeAlias"); }
            set { BackingStore?.Set("exchangeAlias", value); }
        }
        /// <summary>The type of Exchange Connector.</summary>
        public DeviceManagementExchangeConnectorType? ExchangeConnectorType {
            get { return BackingStore?.Get<DeviceManagementExchangeConnectorType?>("exchangeConnectorType"); }
            set { BackingStore?.Set("exchangeConnectorType", value); }
        }
        /// <summary>Exchange Organization to the Exchange server</summary>
        public string ExchangeOrganization {
            get { return BackingStore?.Get<string>("exchangeOrganization"); }
            set { BackingStore?.Set("exchangeOrganization", value); }
        }
        /// <summary>Last sync time for the Exchange Connector</summary>
        public DateTimeOffset? LastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastSyncDateTime"); }
            set { BackingStore?.Set("lastSyncDateTime", value); }
        }
        /// <summary>Email address used to configure the Service To Service Exchange Connector.</summary>
        public string PrimarySmtpAddress {
            get { return BackingStore?.Get<string>("primarySmtpAddress"); }
            set { BackingStore?.Set("primarySmtpAddress", value); }
        }
        /// <summary>The name of the Exchange server.</summary>
        public string ServerName {
            get { return BackingStore?.Get<string>("serverName"); }
            set { BackingStore?.Set("serverName", value); }
        }
        /// <summary>The current status of the Exchange Connector.</summary>
        public DeviceManagementExchangeConnectorStatus? Status {
            get { return BackingStore?.Get<DeviceManagementExchangeConnectorStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>The version of the ExchangeConnectorAgent</summary>
        public string Version {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceManagementExchangeConnector CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceManagementExchangeConnector();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"connectorServerName", n => { ConnectorServerName = n.GetStringValue(); } },
                {"exchangeAlias", n => { ExchangeAlias = n.GetStringValue(); } },
                {"exchangeConnectorType", n => { ExchangeConnectorType = n.GetEnumValue<DeviceManagementExchangeConnectorType>(); } },
                {"exchangeOrganization", n => { ExchangeOrganization = n.GetStringValue(); } },
                {"lastSyncDateTime", n => { LastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"primarySmtpAddress", n => { PrimarySmtpAddress = n.GetStringValue(); } },
                {"serverName", n => { ServerName = n.GetStringValue(); } },
                {"status", n => { Status = n.GetEnumValue<DeviceManagementExchangeConnectorStatus>(); } },
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
            writer.WriteStringValue("connectorServerName", ConnectorServerName);
            writer.WriteStringValue("exchangeAlias", ExchangeAlias);
            writer.WriteEnumValue<DeviceManagementExchangeConnectorType>("exchangeConnectorType", ExchangeConnectorType);
            writer.WriteStringValue("exchangeOrganization", ExchangeOrganization);
            writer.WriteDateTimeOffsetValue("lastSyncDateTime", LastSyncDateTime);
            writer.WriteStringValue("primarySmtpAddress", PrimarySmtpAddress);
            writer.WriteStringValue("serverName", ServerName);
            writer.WriteEnumValue<DeviceManagementExchangeConnectorStatus>("status", Status);
            writer.WriteStringValue("version", Version);
        }
    }
}
