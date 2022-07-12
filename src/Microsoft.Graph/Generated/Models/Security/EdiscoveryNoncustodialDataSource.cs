using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class EdiscoveryNoncustodialDataSource : DataSourceContainer, IParsable {
        /// <summary>User source or SharePoint site data source as non-custodial data source.</summary>
        public Microsoft.Graph.Models.Security.DataSource DataSource {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Security.DataSource>("dataSource"); }
            set { BackingStore?.Set("dataSource", value); }
        }
        /// <summary>Operation entity that represents the latest indexing for the non-custodial data source.</summary>
        public EdiscoveryIndexOperation LastIndexOperation {
            get { return BackingStore?.Get<EdiscoveryIndexOperation>("lastIndexOperation"); }
            set { BackingStore?.Set("lastIndexOperation", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EdiscoveryNoncustodialDataSource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EdiscoveryNoncustodialDataSource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"dataSource", n => { DataSource = n.GetObjectValue<Microsoft.Graph.Models.Security.DataSource>(Microsoft.Graph.Models.Security.DataSource.CreateFromDiscriminatorValue); } },
                {"lastIndexOperation", n => { LastIndexOperation = n.GetObjectValue<EdiscoveryIndexOperation>(EdiscoveryIndexOperation.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.Security.DataSource>("dataSource", DataSource);
            writer.WriteObjectValue<EdiscoveryIndexOperation>("lastIndexOperation", LastIndexOperation);
        }
    }
}
