using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Photo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Camera manufacturer. Read-only.</summary>
        public string CameraMake {
            get { return BackingStore?.Get<string>("cameraMake"); }
            set { BackingStore?.Set("cameraMake", value); }
        }
        /// <summary>Camera model. Read-only.</summary>
        public string CameraModel {
            get { return BackingStore?.Get<string>("cameraModel"); }
            set { BackingStore?.Set("cameraModel", value); }
        }
        /// <summary>The denominator for the exposure time fraction from the camera. Read-only.</summary>
        public double? ExposureDenominator {
            get { return BackingStore?.Get<double?>("exposureDenominator"); }
            set { BackingStore?.Set("exposureDenominator", value); }
        }
        /// <summary>The numerator for the exposure time fraction from the camera. Read-only.</summary>
        public double? ExposureNumerator {
            get { return BackingStore?.Get<double?>("exposureNumerator"); }
            set { BackingStore?.Set("exposureNumerator", value); }
        }
        /// <summary>The F-stop value from the camera. Read-only.</summary>
        public double? FNumber {
            get { return BackingStore?.Get<double?>("fNumber"); }
            set { BackingStore?.Set("fNumber", value); }
        }
        /// <summary>The focal length from the camera. Read-only.</summary>
        public double? FocalLength {
            get { return BackingStore?.Get<double?>("focalLength"); }
            set { BackingStore?.Set("focalLength", value); }
        }
        /// <summary>The ISO value from the camera. Read-only.</summary>
        public int? Iso {
            get { return BackingStore?.Get<int?>("iso"); }
            set { BackingStore?.Set("iso", value); }
        }
        /// <summary>The orientation value from the camera. Writable on OneDrive Personal.</summary>
        public int? Orientation {
            get { return BackingStore?.Get<int?>("orientation"); }
            set { BackingStore?.Set("orientation", value); }
        }
        /// <summary>The date and time the photo was taken in UTC time. Read-only.</summary>
        public DateTimeOffset? TakenDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("takenDateTime"); }
            set { BackingStore?.Set("takenDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new photo and sets the default values.
        /// </summary>
        public Photo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Photo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Photo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cameraMake", n => { CameraMake = n.GetStringValue(); } },
                {"cameraModel", n => { CameraModel = n.GetStringValue(); } },
                {"exposureDenominator", n => { ExposureDenominator = n.GetDoubleValue(); } },
                {"exposureNumerator", n => { ExposureNumerator = n.GetDoubleValue(); } },
                {"fNumber", n => { FNumber = n.GetDoubleValue(); } },
                {"focalLength", n => { FocalLength = n.GetDoubleValue(); } },
                {"iso", n => { Iso = n.GetIntValue(); } },
                {"orientation", n => { Orientation = n.GetIntValue(); } },
                {"takenDateTime", n => { TakenDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("cameraMake", CameraMake);
            writer.WriteStringValue("cameraModel", CameraModel);
            writer.WriteDoubleValue("exposureDenominator", ExposureDenominator);
            writer.WriteDoubleValue("exposureNumerator", ExposureNumerator);
            writer.WriteDoubleValue("fNumber", FNumber);
            writer.WriteDoubleValue("focalLength", FocalLength);
            writer.WriteIntValue("iso", Iso);
            writer.WriteIntValue("orientation", Orientation);
            writer.WriteDateTimeOffsetValue("takenDateTime", TakenDateTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
