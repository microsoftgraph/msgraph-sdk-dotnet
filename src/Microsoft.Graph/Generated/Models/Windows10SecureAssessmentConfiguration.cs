using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Windows10SecureAssessmentConfiguration : DeviceConfiguration, IParsable {
        /// <summary>Indicates whether or not to allow the app from printing during the test.</summary>
        public bool? AllowPrinting {
            get { return BackingStore?.Get<bool?>("allowPrinting"); }
            set { BackingStore?.Set("allowPrinting", value); }
        }
        /// <summary>Indicates whether or not to allow screen capture capability during a test.</summary>
        public bool? AllowScreenCapture {
            get { return BackingStore?.Get<bool?>("allowScreenCapture"); }
            set { BackingStore?.Set("allowScreenCapture", value); }
        }
        /// <summary>Indicates whether or not to allow text suggestions during the test.</summary>
        public bool? AllowTextSuggestion {
            get { return BackingStore?.Get<bool?>("allowTextSuggestion"); }
            set { BackingStore?.Set("allowTextSuggestion", value); }
        }
        /// <summary>The account used to configure the Windows device for taking the test. The user can be a domain account (domain/user), an AAD account (username@tenant.com) or a local account (username).</summary>
        public string ConfigurationAccount {
            get { return BackingStore?.Get<string>("configurationAccount"); }
            set { BackingStore?.Set("configurationAccount", value); }
        }
        /// <summary>Url link to an assessment that&apos;s automatically loaded when the secure assessment browser is launched. It has to be a valid Url (http[s]://msdn.microsoft.com/).</summary>
        public string LaunchUri {
            get { return BackingStore?.Get<string>("launchUri"); }
            set { BackingStore?.Set("launchUri", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Windows10SecureAssessmentConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Windows10SecureAssessmentConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allowPrinting", n => { AllowPrinting = n.GetBoolValue(); } },
                {"allowScreenCapture", n => { AllowScreenCapture = n.GetBoolValue(); } },
                {"allowTextSuggestion", n => { AllowTextSuggestion = n.GetBoolValue(); } },
                {"configurationAccount", n => { ConfigurationAccount = n.GetStringValue(); } },
                {"launchUri", n => { LaunchUri = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("allowPrinting", AllowPrinting);
            writer.WriteBoolValue("allowScreenCapture", AllowScreenCapture);
            writer.WriteBoolValue("allowTextSuggestion", AllowTextSuggestion);
            writer.WriteStringValue("configurationAccount", ConfigurationAccount);
            writer.WriteStringValue("launchUri", LaunchUri);
        }
    }
}
