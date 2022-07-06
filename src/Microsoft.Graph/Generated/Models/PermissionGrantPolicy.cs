using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PermissionGrantPolicy : PolicyBase, IParsable {
        /// <summary>Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.</summary>
        public List<PermissionGrantConditionSet> Excludes {
            get { return BackingStore?.Get<List<PermissionGrantConditionSet>>("excludes"); }
            set { BackingStore?.Set("excludes", value); }
        }
        /// <summary>Condition sets which are included in this permission grant policy. Automatically expanded on GET.</summary>
        public List<PermissionGrantConditionSet> Includes {
            get { return BackingStore?.Get<List<PermissionGrantConditionSet>>("includes"); }
            set { BackingStore?.Set("includes", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PermissionGrantPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PermissionGrantPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"excludes", n => { Excludes = n.GetCollectionOfObjectValues<PermissionGrantConditionSet>(PermissionGrantConditionSet.CreateFromDiscriminatorValue).ToList(); } },
                {"includes", n => { Includes = n.GetCollectionOfObjectValues<PermissionGrantConditionSet>(PermissionGrantConditionSet.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<PermissionGrantConditionSet>("excludes", Excludes);
            writer.WriteCollectionOfObjectValues<PermissionGrantConditionSet>("includes", Includes);
        }
    }
}
