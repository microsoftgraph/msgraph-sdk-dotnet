using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum IdentityUserFlowAttributeInputType {
        [EnumMember(Value = "checkboxMultiSelect")]
        CheckboxMultiSelect,
        [EnumMember(Value = "dateTimeDropdown")]
        DateTimeDropdown,
        [EnumMember(Value = "dropdownSingleSelect")]
        DropdownSingleSelect,
        [EnumMember(Value = "emailBox")]
        EmailBox,
        [EnumMember(Value = "radioSingleSelect")]
        RadioSingleSelect,
        [EnumMember(Value = "textBox")]
        TextBox,
    }
}
