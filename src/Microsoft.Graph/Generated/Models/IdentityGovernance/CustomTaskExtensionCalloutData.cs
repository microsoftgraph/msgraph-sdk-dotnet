using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public class CustomTaskExtensionCalloutData : CustomExtensionData, IParsable {
        /// <summary>The subject property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.User? Subject {
            get { return BackingStore?.Get<Microsoft.Graph.Models.User?>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.User Subject {
            get { return BackingStore?.Get<Microsoft.Graph.Models.User>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
#endif
        /// <summary>The task property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.IdentityGovernance.TaskObject? TaskObject {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.TaskObject?>("task"); }
            set { BackingStore?.Set("task", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.IdentityGovernance.TaskObject TaskObject {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.TaskObject>("task"); }
            set { BackingStore?.Set("task", value); }
        }
#endif
        /// <summary>The taskProcessingresult property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult? TaskProcessingresult {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult?>("taskProcessingresult"); }
            set { BackingStore?.Set("taskProcessingresult", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult TaskProcessingresult {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult>("taskProcessingresult"); }
            set { BackingStore?.Set("taskProcessingresult", value); }
        }
#endif
        /// <summary>The workflow property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.IdentityGovernance.Workflow? Workflow {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.Workflow?>("workflow"); }
            set { BackingStore?.Set("workflow", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.IdentityGovernance.Workflow Workflow {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentityGovernance.Workflow>("workflow"); }
            set { BackingStore?.Set("workflow", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new customTaskExtensionCalloutData and sets the default values.
        /// </summary>
        public CustomTaskExtensionCalloutData() : base() {
            OdataType = "#microsoft.graph.identityGovernance.customTaskExtensionCalloutData";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new CustomTaskExtensionCalloutData CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CustomTaskExtensionCalloutData();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"subject", n => { Subject = n.GetObjectValue<Microsoft.Graph.Models.User>(Microsoft.Graph.Models.User.CreateFromDiscriminatorValue); } },
                {"task", n => { TaskObject = n.GetObjectValue<Microsoft.Graph.Models.IdentityGovernance.TaskObject>(Microsoft.Graph.Models.IdentityGovernance.TaskObject.CreateFromDiscriminatorValue); } },
                {"taskProcessingresult", n => { TaskProcessingresult = n.GetObjectValue<Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult>(Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult.CreateFromDiscriminatorValue); } },
                {"workflow", n => { Workflow = n.GetObjectValue<Microsoft.Graph.Models.IdentityGovernance.Workflow>(Microsoft.Graph.Models.IdentityGovernance.Workflow.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.User>("subject", Subject);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentityGovernance.TaskObject>("task", TaskObject);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentityGovernance.TaskProcessingResult>("taskProcessingresult", TaskProcessingresult);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentityGovernance.Workflow>("workflow", Workflow);
        }
    }
}
