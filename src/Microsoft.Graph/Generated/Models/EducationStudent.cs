using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationStudent : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Birth date of the student.</summary>
        public Date? BirthDate {
            get { return BackingStore?.Get<Date?>("birthDate"); }
            set { BackingStore?.Set("birthDate", value); }
        }
        /// <summary>ID of the student in the source system.</summary>
        public string ExternalId {
            get { return BackingStore?.Get<string>("externalId"); }
            set { BackingStore?.Set("externalId", value); }
        }
        /// <summary>Possible values are: female, male, other.</summary>
        public EducationGender? Gender {
            get { return BackingStore?.Get<EducationGender?>("gender"); }
            set { BackingStore?.Set("gender", value); }
        }
        /// <summary>Current grade level of the student.</summary>
        public string Grade {
            get { return BackingStore?.Get<string>("grade"); }
            set { BackingStore?.Set("grade", value); }
        }
        /// <summary>Year the student is graduating from the school.</summary>
        public string GraduationYear {
            get { return BackingStore?.Get<string>("graduationYear"); }
            set { BackingStore?.Set("graduationYear", value); }
        }
        /// <summary>Student Number.</summary>
        public string StudentNumber {
            get { return BackingStore?.Get<string>("studentNumber"); }
            set { BackingStore?.Set("studentNumber", value); }
        }
        /// <summary>
        /// Instantiates a new educationStudent and sets the default values.
        /// </summary>
        public EducationStudent() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static EducationStudent CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationStudent();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"birthDate", n => { BirthDate = n.GetDateValue(); } },
                {"externalId", n => { ExternalId = n.GetStringValue(); } },
                {"gender", n => { Gender = n.GetEnumValue<EducationGender>(); } },
                {"grade", n => { Grade = n.GetStringValue(); } },
                {"graduationYear", n => { GraduationYear = n.GetStringValue(); } },
                {"studentNumber", n => { StudentNumber = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateValue("birthDate", BirthDate);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteEnumValue<EducationGender>("gender", Gender);
            writer.WriteStringValue("grade", Grade);
            writer.WriteStringValue("graduationYear", GraduationYear);
            writer.WriteStringValue("studentNumber", StudentNumber);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
