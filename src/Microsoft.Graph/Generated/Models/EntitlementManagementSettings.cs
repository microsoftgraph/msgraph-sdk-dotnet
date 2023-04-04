using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class EntitlementManagementSettings : Entity, IParsable {
        /// <summary>If externalUserLifecycleAction is blockSignInAndDelete, the duration, typically a number of days, after an external user is blocked from sign in before their account is deleted.</summary>
        public TimeSpan? DurationUntilExternalUserDeletedAfterBlocked {
            get { return BackingStore?.Get<TimeSpan?>("durationUntilExternalUserDeletedAfterBlocked"); }
            set { BackingStore?.Set("durationUntilExternalUserDeletedAfterBlocked", value); }
        }
        /// <summary>Automatic action that the service should take when an external user&apos;s last access package assignment is removed. The possible values are: none, blockSignIn, blockSignInAndDelete, unknownFutureValue.</summary>
        public AccessPackageExternalUserLifecycleAction? ExternalUserLifecycleAction {
            get { return BackingStore?.Get<AccessPackageExternalUserLifecycleAction?>("externalUserLifecycleAction"); }
            set { BackingStore?.Set("externalUserLifecycleAction", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new EntitlementManagementSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EntitlementManagementSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"durationUntilExternalUserDeletedAfterBlocked", n => { DurationUntilExternalUserDeletedAfterBlocked = n.GetTimeSpanValue(); } },
                {"externalUserLifecycleAction", n => { ExternalUserLifecycleAction = n.GetEnumValue<AccessPackageExternalUserLifecycleAction>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteTimeSpanValue("durationUntilExternalUserDeletedAfterBlocked", DurationUntilExternalUserDeletedAfterBlocked);
            writer.WriteEnumValue<AccessPackageExternalUserLifecycleAction>("externalUserLifecycleAction", ExternalUserLifecycleAction);
        }
    }
}
