using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum QuarantineReason {
        [EnumMember(Value = "EncounteredBaseEscrowThreshold")]
        EncounteredBaseEscrowThreshold,
        [EnumMember(Value = "EncounteredEscrowProportionThreshold")]
        EncounteredEscrowProportionThreshold,
        [EnumMember(Value = "EncounteredQuarantineException")]
        EncounteredQuarantineException,
        [EnumMember(Value = "EncounteredTotalEscrowThreshold")]
        EncounteredTotalEscrowThreshold,
        [EnumMember(Value = "IngestionInterrupted")]
        IngestionInterrupted,
        [EnumMember(Value = "QuarantinedOnDemand")]
        QuarantinedOnDemand,
        [EnumMember(Value = "TooManyDeletes")]
        TooManyDeletes,
        [EnumMember(Value = "Unknown")]
        Unknown,
    }
}
