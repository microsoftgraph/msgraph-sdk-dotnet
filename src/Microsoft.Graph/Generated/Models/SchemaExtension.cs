using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SchemaExtension : Entity, IParsable {
        /// <summary>Description for the schema extension. Supports $filter (eq).</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The appId of the application that is the owner of the schema extension. This property can be supplied on creation, to set the owner.  If not supplied, then the calling application&apos;s appId will be set as the owner. In either case, the signed-in user must be the owner of the application. So, for example, if creating a new schema extension definition using Graph Explorer, you must supply the owner property. Once set, this property is read-only and cannot be changed. Supports $filter (eq).</summary>
        public string Owner {
            get { return BackingStore?.Get<string>("owner"); }
            set { BackingStore?.Set("owner", value); }
        }
        /// <summary>The collection of property names and types that make up the schema extension definition.</summary>
        public List<ExtensionSchemaProperty> Properties {
            get { return BackingStore?.Get<List<ExtensionSchemaProperty>>("properties"); }
            set { BackingStore?.Set("properties", value); }
        }
        /// <summary>The lifecycle state of the schema extension. Possible states are InDevelopment, Available, and Deprecated. Automatically set to InDevelopment on creation. For more information about the possible state transitions and behaviors, see Schema extensions lifecycle. Supports $filter (eq).</summary>
        public string Status {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Set of Microsoft Graph types (that can support extensions) that the schema extension can be applied to. Select from administrativeUnit, contact, device, event, group, message, organization, post, todoTask, todoTaskList, or user.</summary>
        public List<string> TargetTypes {
            get { return BackingStore?.Get<List<string>>("targetTypes"); }
            set { BackingStore?.Set("targetTypes", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SchemaExtension CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SchemaExtension();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"description", n => { Description = n.GetStringValue(); } },
                {"owner", n => { Owner = n.GetStringValue(); } },
                {"properties", n => { Properties = n.GetCollectionOfObjectValues<ExtensionSchemaProperty>(ExtensionSchemaProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"status", n => { Status = n.GetStringValue(); } },
                {"targetTypes", n => { TargetTypes = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("owner", Owner);
            writer.WriteCollectionOfObjectValues<ExtensionSchemaProperty>("properties", Properties);
            writer.WriteStringValue("status", Status);
            writer.WriteCollectionOfPrimitiveValues<string>("targetTypes", TargetTypes);
        }
    }
}
