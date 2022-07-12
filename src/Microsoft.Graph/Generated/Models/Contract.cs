using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Contract : DirectoryObject, IParsable {
        /// <summary>Type of contract. Possible values are:  SyndicationPartner, BreadthPartner, ResellerPartner. See more in the table below.</summary>
        public string ContractType {
            get { return BackingStore?.Get<string>("contractType"); }
            set { BackingStore?.Set("contractType", value); }
        }
        /// <summary>The unique identifier for the customer tenant referenced by this partnership. Corresponds to the id property of the customer tenant&apos;s organization resource.</summary>
        public string CustomerId {
            get { return BackingStore?.Get<string>("customerId"); }
            set { BackingStore?.Set("customerId", value); }
        }
        /// <summary>A copy of the customer tenant&apos;s default domain name. The copy is made when the partnership with the customer is established. It is not automatically updated if the customer tenant&apos;s default domain name changes.</summary>
        public string DefaultDomainName {
            get { return BackingStore?.Get<string>("defaultDomainName"); }
            set { BackingStore?.Set("defaultDomainName", value); }
        }
        /// <summary>A copy of the customer tenant&apos;s display name. The copy is made when the partnership with the customer is established. It is not automatically updated if the customer tenant&apos;s display name changes.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Contract CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Contract();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"contractType", n => { ContractType = n.GetStringValue(); } },
                {"customerId", n => { CustomerId = n.GetStringValue(); } },
                {"defaultDomainName", n => { DefaultDomainName = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("contractType", ContractType);
            writer.WriteStringValue("customerId", CustomerId);
            writer.WriteStringValue("defaultDomainName", DefaultDomainName);
            writer.WriteStringValue("displayName", DisplayName);
        }
    }
}
