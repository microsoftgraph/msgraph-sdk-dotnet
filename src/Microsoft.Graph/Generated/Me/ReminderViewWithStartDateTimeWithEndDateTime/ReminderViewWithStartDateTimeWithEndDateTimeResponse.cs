// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Me.ReminderViewWithStartDateTimeWithEndDateTime
{
    [Obsolete("This class is obsolete. Use ReminderViewWithStartDateTimeWithEndDateTimeGetResponse instead.")]
    #pragma warning disable CS1591
    public class ReminderViewWithStartDateTimeWithEndDateTimeResponse : Microsoft.Graph.Me.ReminderViewWithStartDateTimeWithEndDateTime.ReminderViewWithStartDateTimeWithEndDateTimeGetResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Me.ReminderViewWithStartDateTimeWithEndDateTime.ReminderViewWithStartDateTimeWithEndDateTimeResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Me.ReminderViewWithStartDateTimeWithEndDateTime.ReminderViewWithStartDateTimeWithEndDateTimeResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Me.ReminderViewWithStartDateTimeWithEndDateTime.ReminderViewWithStartDateTimeWithEndDateTimeResponse();
        }
    }
}
