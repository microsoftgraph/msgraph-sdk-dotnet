using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class AppConsentRequest : Entity, IParsable {
        /// <summary>The display name of the app for which consent is requested. Required. Supports $filter (eq only) and $orderby.</summary>
        public string AppDisplayName {
            get { return BackingStore?.Get<string>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
        /// <summary>The identifier of the application. Required. Supports $filter (eq only) and $orderby.</summary>
        public string AppId {
            get { return BackingStore?.Get<string>("appId"); }
            set { BackingStore?.Set("appId", value); }
        }
        /// <summary>A list of pending scopes waiting for approval. This is empty if the consentType is Static. Required.</summary>
        public List<AppConsentRequestScope> PendingScopes {
            get { return BackingStore?.Get<List<AppConsentRequestScope>>("pendingScopes"); }
            set { BackingStore?.Set("pendingScopes", value); }
        }
        /// <summary>A list of pending user consent requests.</summary>
        public List<UserConsentRequest> UserConsentRequests {
            get { return BackingStore?.Get<List<UserConsentRequest>>("userConsentRequests"); }
            set { BackingStore?.Set("userConsentRequests", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AppConsentRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AppConsentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appDisplayName", n => { AppDisplayName = n.GetStringValue(); } },
                {"appId", n => { AppId = n.GetStringValue(); } },
                {"pendingScopes", n => { PendingScopes = n.GetCollectionOfObjectValues<AppConsentRequestScope>(AppConsentRequestScope.CreateFromDiscriminatorValue).ToList(); } },
                {"userConsentRequests", n => { UserConsentRequests = n.GetCollectionOfObjectValues<UserConsentRequest>(UserConsentRequest.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appDisplayName", AppDisplayName);
            writer.WriteStringValue("appId", AppId);
            writer.WriteCollectionOfObjectValues<AppConsentRequestScope>("pendingScopes", PendingScopes);
            writer.WriteCollectionOfObjectValues<UserConsentRequest>("userConsentRequests", UserConsentRequests);
        }
    }
}
