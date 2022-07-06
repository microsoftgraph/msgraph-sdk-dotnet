using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ReportRoot : Entity, IParsable {
        /// <summary>The dailyPrintUsageByPrinter property</summary>
        public List<PrintUsageByPrinter> DailyPrintUsageByPrinter {
            get { return BackingStore?.Get<List<PrintUsageByPrinter>>("dailyPrintUsageByPrinter"); }
            set { BackingStore?.Set("dailyPrintUsageByPrinter", value); }
        }
        /// <summary>The dailyPrintUsageByUser property</summary>
        public List<PrintUsageByUser> DailyPrintUsageByUser {
            get { return BackingStore?.Get<List<PrintUsageByUser>>("dailyPrintUsageByUser"); }
            set { BackingStore?.Set("dailyPrintUsageByUser", value); }
        }
        /// <summary>The monthlyPrintUsageByPrinter property</summary>
        public List<PrintUsageByPrinter> MonthlyPrintUsageByPrinter {
            get { return BackingStore?.Get<List<PrintUsageByPrinter>>("monthlyPrintUsageByPrinter"); }
            set { BackingStore?.Set("monthlyPrintUsageByPrinter", value); }
        }
        /// <summary>The monthlyPrintUsageByUser property</summary>
        public List<PrintUsageByUser> MonthlyPrintUsageByUser {
            get { return BackingStore?.Get<List<PrintUsageByUser>>("monthlyPrintUsageByUser"); }
            set { BackingStore?.Set("monthlyPrintUsageByUser", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ReportRoot CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ReportRoot();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"dailyPrintUsageByPrinter", n => { DailyPrintUsageByPrinter = n.GetCollectionOfObjectValues<PrintUsageByPrinter>(PrintUsageByPrinter.CreateFromDiscriminatorValue).ToList(); } },
                {"dailyPrintUsageByUser", n => { DailyPrintUsageByUser = n.GetCollectionOfObjectValues<PrintUsageByUser>(PrintUsageByUser.CreateFromDiscriminatorValue).ToList(); } },
                {"monthlyPrintUsageByPrinter", n => { MonthlyPrintUsageByPrinter = n.GetCollectionOfObjectValues<PrintUsageByPrinter>(PrintUsageByPrinter.CreateFromDiscriminatorValue).ToList(); } },
                {"monthlyPrintUsageByUser", n => { MonthlyPrintUsageByUser = n.GetCollectionOfObjectValues<PrintUsageByUser>(PrintUsageByUser.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<PrintUsageByPrinter>("dailyPrintUsageByPrinter", DailyPrintUsageByPrinter);
            writer.WriteCollectionOfObjectValues<PrintUsageByUser>("dailyPrintUsageByUser", DailyPrintUsageByUser);
            writer.WriteCollectionOfObjectValues<PrintUsageByPrinter>("monthlyPrintUsageByPrinter", MonthlyPrintUsageByPrinter);
            writer.WriteCollectionOfObjectValues<PrintUsageByUser>("monthlyPrintUsageByUser", MonthlyPrintUsageByUser);
        }
    }
}
