using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for Miracast channel.</summary>
    public enum MiracastChannel {
        /// <summary>Eight.</summary>
        [EnumMember(Value = "eight")]
        Eight,
        /// <summary>Eleven.</summary>
        [EnumMember(Value = "eleven")]
        Eleven,
        /// <summary>Five.</summary>
        [EnumMember(Value = "five")]
        Five,
        /// <summary>Forty.</summary>
        [EnumMember(Value = "forty")]
        Forty,
        /// <summary>Forty-Eight.</summary>
        [EnumMember(Value = "fortyEight")]
        FortyEight,
        /// <summary>Forty-Four.</summary>
        [EnumMember(Value = "fortyFour")]
        FortyFour,
        /// <summary>Four.</summary>
        [EnumMember(Value = "four")]
        Four,
        /// <summary>Nine.</summary>
        [EnumMember(Value = "nine")]
        Nine,
        /// <summary>One.</summary>
        [EnumMember(Value = "one")]
        One,
        /// <summary>OneHundredFifty-Seven.</summary>
        [EnumMember(Value = "oneHundredFiftySeven")]
        OneHundredFiftySeven,
        /// <summary>OneHundredFifty-Three.</summary>
        [EnumMember(Value = "oneHundredFiftyThree")]
        OneHundredFiftyThree,
        /// <summary>OneHundredForty-Nine.</summary>
        [EnumMember(Value = "oneHundredFortyNine")]
        OneHundredFortyNine,
        /// <summary>OneHundredSixty-Five.</summary>
        [EnumMember(Value = "oneHundredSixtyFive")]
        OneHundredSixtyFive,
        /// <summary>OneHundredSixty-One.</summary>
        [EnumMember(Value = "oneHundredSixtyOne")]
        OneHundredSixtyOne,
        /// <summary>Seven.</summary>
        [EnumMember(Value = "seven")]
        Seven,
        /// <summary>Six.</summary>
        [EnumMember(Value = "six")]
        Six,
        /// <summary>Ten.</summary>
        [EnumMember(Value = "ten")]
        Ten,
        /// <summary>Thirty-Six.</summary>
        [EnumMember(Value = "thirtySix")]
        ThirtySix,
        /// <summary>Three.</summary>
        [EnumMember(Value = "three")]
        Three,
        /// <summary>Two.</summary>
        [EnumMember(Value = "two")]
        Two,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
