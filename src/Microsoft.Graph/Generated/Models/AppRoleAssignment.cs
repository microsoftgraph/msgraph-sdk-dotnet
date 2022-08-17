using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class AppRoleAssignment : DirectoryObject, IParsable {
        /// <summary>The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application&apos;s service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.</summary>
        public string AppRoleId {
            get { return BackingStore?.Get<string>("appRoleId"); }
            set { BackingStore?.Set("appRoleId", value); }
        }
        /// <summary>The time when the app role assignment was created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).</summary>
        public string PrincipalDisplayName {
            get { return BackingStore?.Get<string>("principalDisplayName"); }
            set { BackingStore?.Set("principalDisplayName", value); }
        }
        /// <summary>The unique identifier (id) for the user, group, or service principal being granted the app role. Required on create.</summary>
        public string PrincipalId {
            get { return BackingStore?.Get<string>("principalId"); }
            set { BackingStore?.Set("principalId", value); }
        }
        /// <summary>The type of the assigned principal. This can either be User, Group, or ServicePrincipal. Read-only.</summary>
        public string PrincipalType {
            get { return BackingStore?.Get<string>("principalType"); }
            set { BackingStore?.Set("principalType", value); }
        }
        /// <summary>The display name of the resource app&apos;s service principal to which the assignment is made.</summary>
        public string ResourceDisplayName {
            get { return BackingStore?.Get<string>("resourceDisplayName"); }
            set { BackingStore?.Set("resourceDisplayName", value); }
        }
        /// <summary>The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).</summary>
        public string ResourceId {
            get { return BackingStore?.Get<string>("resourceId"); }
            set { BackingStore?.Set("resourceId", value); }
        }
        /// <summary>
        /// Instantiates a new appRoleAssignment and sets the default values.
        /// </summary>
        public AppRoleAssignment() : base() {
            OdataType = "#microsoft.graph.appRoleAssignment";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AppRoleAssignment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AppRoleAssignment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appRoleId", n => { AppRoleId = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"principalDisplayName", n => { PrincipalDisplayName = n.GetStringValue(); } },
                {"principalId", n => { PrincipalId = n.GetStringValue(); } },
                {"principalType", n => { PrincipalType = n.GetStringValue(); } },
                {"resourceDisplayName", n => { ResourceDisplayName = n.GetStringValue(); } },
                {"resourceId", n => { ResourceId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appRoleId", AppRoleId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("principalDisplayName", PrincipalDisplayName);
            writer.WriteStringValue("principalId", PrincipalId);
            writer.WriteStringValue("principalType", PrincipalType);
            writer.WriteStringValue("resourceDisplayName", ResourceDisplayName);
            writer.WriteStringValue("resourceId", ResourceId);
        }
    }
}
