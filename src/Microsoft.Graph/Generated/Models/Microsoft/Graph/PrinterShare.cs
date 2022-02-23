using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class PrinterShare : PrinterBase, IParsable {
        /// <summary>If true, all users and groups will be granted access to this printer share. This supersedes the allow lists defined by the allowedUsers and allowedGroups navigation properties.</summary>
        public bool? AllowAllUsers { get; set; }
        /// <summary>The groups whose users have access to print using the printer.</summary>
        public List<Group> AllowedGroups { get; set; }
        /// <summary>The users who have access to print using the printer.</summary>
        public List<User> AllowedUsers { get; set; }
        /// <summary>The DateTimeOffset when the printer share was created. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The printer that this printer share is related to.</summary>
        public Printer Printer { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"allowAllUsers", (o,n) => { (o as PrinterShare).AllowAllUsers = n.GetBoolValue(); } },
                {"allowedGroups", (o,n) => { (o as PrinterShare).AllowedGroups = n.GetCollectionOfObjectValues<Group>().ToList(); } },
                {"allowedUsers", (o,n) => { (o as PrinterShare).AllowedUsers = n.GetCollectionOfObjectValues<User>().ToList(); } },
                {"createdDateTime", (o,n) => { (o as PrinterShare).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"printer", (o,n) => { (o as PrinterShare).Printer = n.GetObjectValue<Printer>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("allowAllUsers", AllowAllUsers);
            writer.WriteCollectionOfObjectValues<Group>("allowedGroups", AllowedGroups);
            writer.WriteCollectionOfObjectValues<User>("allowedUsers", AllowedUsers);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<Printer>("printer", Printer);
        }
    }
}
