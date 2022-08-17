namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum AccessPackageRequestType {
        NotSpecified,
        UserAdd,
        UserUpdate,
        UserRemove,
        AdminAdd,
        AdminUpdate,
        AdminRemove,
        SystemAdd,
        SystemUpdate,
        SystemRemove,
        OnBehalfAdd,
        UnknownFutureValue,
    }
}
