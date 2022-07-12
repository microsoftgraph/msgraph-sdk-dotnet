using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewQueryScope : AccessReviewScope, IParsable {
        /// <summary>The query representing what will be reviewed in an access review.</summary>
        public string Query {
            get { return BackingStore?.Get<string>("query"); }
            set { BackingStore?.Set("query", value); }
        }
        /// <summary>In the scenario where reviewers need to be specified dynamically, this property is used to indicate the relative source of the query. This property is only required if a relative query is specified. For example, ./manager.</summary>
        public string QueryRoot {
            get { return BackingStore?.Get<string>("queryRoot"); }
            set { BackingStore?.Set("queryRoot", value); }
        }
        /// <summary>Indicates the type of query. Types include MicrosoftGraph and ARM.</summary>
        public string QueryType {
            get { return BackingStore?.Get<string>("queryType"); }
            set { BackingStore?.Set("queryType", value); }
        }
        /// <summary>
        /// Instantiates a new AccessReviewQueryScope and sets the default values.
        /// </summary>
        public AccessReviewQueryScope() : base() {
            Type = "#microsoft.graph.accessReviewQueryScope";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessReviewQueryScope CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.accessReviewInactiveUsersQueryScope" => new AccessReviewInactiveUsersQueryScope(),
                _ => new AccessReviewQueryScope(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"query", n => { Query = n.GetStringValue(); } },
                {"queryRoot", n => { QueryRoot = n.GetStringValue(); } },
                {"queryType", n => { QueryType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("query", Query);
            writer.WriteStringValue("queryRoot", QueryRoot);
            writer.WriteStringValue("queryType", QueryType);
        }
    }
}
