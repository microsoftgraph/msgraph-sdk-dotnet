using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodsPolicyMigrationState {
        [EnumMember(Value = "migrationComplete")]
        MigrationComplete,
        [EnumMember(Value = "migrationInProgress")]
        MigrationInProgress,
        [EnumMember(Value = "preMigration")]
        PreMigration,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
