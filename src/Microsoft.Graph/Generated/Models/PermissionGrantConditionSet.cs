using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of application entities.</summary>
    public class PermissionGrantConditionSet : Entity, IParsable {
        /// <summary>A list of appId values for the client applications to match with, or a list with the single value all to match any client application. Default is the single value all.</summary>
        public List<string> ClientApplicationIds {
            get { return BackingStore?.Get<List<string>>("clientApplicationIds"); }
            set { BackingStore?.Set("clientApplicationIds", value); }
        }
        /// <summary>A list of Microsoft Partner Network (MPN) IDs for verified publishers of the client application, or a list with the single value all to match with client apps from any publisher. Default is the single value all.</summary>
        public List<string> ClientApplicationPublisherIds {
            get { return BackingStore?.Get<List<string>>("clientApplicationPublisherIds"); }
            set { BackingStore?.Set("clientApplicationPublisherIds", value); }
        }
        /// <summary>Set to true to only match on client applications with a verified publisher. Set to false to match on any client app, even if it does not have a verified publisher. Default is false.</summary>
        public bool? ClientApplicationsFromVerifiedPublisherOnly {
            get { return BackingStore?.Get<bool?>("clientApplicationsFromVerifiedPublisherOnly"); }
            set { BackingStore?.Set("clientApplicationsFromVerifiedPublisherOnly", value); }
        }
        /// <summary>A list of Azure Active Directory tenant IDs in which the client application is registered, or a list with the single value all to match with client apps registered in any tenant. Default is the single value all.</summary>
        public List<string> ClientApplicationTenantIds {
            get { return BackingStore?.Get<List<string>>("clientApplicationTenantIds"); }
            set { BackingStore?.Set("clientApplicationTenantIds", value); }
        }
        /// <summary>The permission classification for the permission being granted, or all to match with any permission classification (including permissions which are not classified). Default is all.</summary>
        public string PermissionClassification {
            get { return BackingStore?.Get<string>("permissionClassification"); }
            set { BackingStore?.Set("permissionClassification", value); }
        }
        /// <summary>The list of id values for the specific permissions to match with, or a list with the single value all to match with any permission. The id of delegated permissions can be found in the oauth2PermissionScopes property of the API&apos;s **servicePrincipal** object. The id of application permissions can be found in the appRoles property of the API&apos;s **servicePrincipal** object. The id of resource-specific application permissions can be found in the resourceSpecificApplicationPermissions property of the API&apos;s **servicePrincipal** object. Default is the single value all.</summary>
        public List<string> Permissions {
            get { return BackingStore?.Get<List<string>>("permissions"); }
            set { BackingStore?.Set("permissions", value); }
        }
        /// <summary>The permission type of the permission being granted. Possible values: application for application permissions (e.g. app roles), or delegated for delegated permissions. The value delegatedUserConsentable indicates delegated permissions which have not been configured by the API publisher to require admin consent—this value may be used in built-in permission grant policies, but cannot be used in custom permission grant policies. Required.</summary>
        public Microsoft.Graph.Models.PermissionType? PermissionType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PermissionType?>("permissionType"); }
            set { BackingStore?.Set("permissionType", value); }
        }
        /// <summary>The appId of the resource application (e.g. the API) for which a permission is being granted, or any to match with any resource application or API. Default is any.</summary>
        public string ResourceApplication {
            get { return BackingStore?.Get<string>("resourceApplication"); }
            set { BackingStore?.Set("resourceApplication", value); }
        }
        /// <summary>
        /// Instantiates a new permissionGrantConditionSet and sets the default values.
        /// </summary>
        public PermissionGrantConditionSet() : base() {
            OdataType = "#microsoft.graph.permissionGrantConditionSet";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PermissionGrantConditionSet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PermissionGrantConditionSet();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"clientApplicationIds", n => { ClientApplicationIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"clientApplicationPublisherIds", n => { ClientApplicationPublisherIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"clientApplicationsFromVerifiedPublisherOnly", n => { ClientApplicationsFromVerifiedPublisherOnly = n.GetBoolValue(); } },
                {"clientApplicationTenantIds", n => { ClientApplicationTenantIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"permissionClassification", n => { PermissionClassification = n.GetStringValue(); } },
                {"permissions", n => { Permissions = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"permissionType", n => { PermissionType = n.GetEnumValue<PermissionType>(); } },
                {"resourceApplication", n => { ResourceApplication = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("clientApplicationIds", ClientApplicationIds);
            writer.WriteCollectionOfPrimitiveValues<string>("clientApplicationPublisherIds", ClientApplicationPublisherIds);
            writer.WriteBoolValue("clientApplicationsFromVerifiedPublisherOnly", ClientApplicationsFromVerifiedPublisherOnly);
            writer.WriteCollectionOfPrimitiveValues<string>("clientApplicationTenantIds", ClientApplicationTenantIds);
            writer.WriteStringValue("permissionClassification", PermissionClassification);
            writer.WriteCollectionOfPrimitiveValues<string>("permissions", Permissions);
            writer.WriteEnumValue<PermissionType>("permissionType", PermissionType);
            writer.WriteStringValue("resourceApplication", ResourceApplication);
        }
    }
}
