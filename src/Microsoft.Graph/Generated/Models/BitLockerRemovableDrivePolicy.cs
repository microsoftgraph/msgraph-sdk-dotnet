using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>BitLocker Removable Drive Policies.</summary>
    public class BitLockerRemovableDrivePolicy : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>This policy setting determines whether BitLocker protection is required for removable data drives to be writable on a computer.</summary>
        public bool? BlockCrossOrganizationWriteAccess {
            get { return BackingStore?.Get<bool?>("blockCrossOrganizationWriteAccess"); }
            set { BackingStore?.Set("blockCrossOrganizationWriteAccess", value); }
        }
        /// <summary>Select the encryption method for removable  drives. Possible values are: aesCbc128, aesCbc256, xtsAes128, xtsAes256.</summary>
        public BitLockerEncryptionMethod? EncryptionMethod {
            get { return BackingStore?.Get<BitLockerEncryptionMethod?>("encryptionMethod"); }
            set { BackingStore?.Set("encryptionMethod", value); }
        }
        /// <summary>Indicates whether to block write access to devices configured in another organization.  If requireEncryptionForWriteAccess is false, this value does not affect.</summary>
        public bool? RequireEncryptionForWriteAccess {
            get { return BackingStore?.Get<bool?>("requireEncryptionForWriteAccess"); }
            set { BackingStore?.Set("requireEncryptionForWriteAccess", value); }
        }
        /// <summary>
        /// Instantiates a new bitLockerRemovableDrivePolicy and sets the default values.
        /// </summary>
        public BitLockerRemovableDrivePolicy() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BitLockerRemovableDrivePolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BitLockerRemovableDrivePolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"blockCrossOrganizationWriteAccess", n => { BlockCrossOrganizationWriteAccess = n.GetBoolValue(); } },
                {"encryptionMethod", n => { EncryptionMethod = n.GetEnumValue<BitLockerEncryptionMethod>(); } },
                {"requireEncryptionForWriteAccess", n => { RequireEncryptionForWriteAccess = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("blockCrossOrganizationWriteAccess", BlockCrossOrganizationWriteAccess);
            writer.WriteEnumValue<BitLockerEncryptionMethod>("encryptionMethod", EncryptionMethod);
            writer.WriteBoolValue("requireEncryptionForWriteAccess", RequireEncryptionForWriteAccess);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
