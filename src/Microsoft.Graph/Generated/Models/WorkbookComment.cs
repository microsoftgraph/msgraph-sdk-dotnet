using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class WorkbookComment : Entity, IParsable {
        /// <summary>The content of the comment.</summary>
        public string Content {
            get { return BackingStore?.Get<string>("content"); }
            set { BackingStore?.Set("content", value); }
        }
        /// <summary>Indicates the type for the comment.</summary>
        public string ContentType {
            get { return BackingStore?.Get<string>("contentType"); }
            set { BackingStore?.Set("contentType", value); }
        }
        /// <summary>The replies property</summary>
        public List<WorkbookCommentReply> Replies {
            get { return BackingStore?.Get<List<WorkbookCommentReply>>("replies"); }
            set { BackingStore?.Set("replies", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookComment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookComment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"content", n => { Content = n.GetStringValue(); } },
                {"contentType", n => { ContentType = n.GetStringValue(); } },
                {"replies", n => { Replies = n.GetCollectionOfObjectValues<WorkbookCommentReply>(WorkbookCommentReply.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("content", Content);
            writer.WriteStringValue("contentType", ContentType);
            writer.WriteCollectionOfObjectValues<WorkbookCommentReply>("replies", Replies);
        }
    }
}
