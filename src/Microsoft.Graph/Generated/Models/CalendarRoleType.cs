namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum CalendarRoleType {
        None,
        FreeBusyRead,
        LimitedRead,
        Read,
        Write,
        DelegateWithoutPrivateEventAccess,
        DelegateWithPrivateEventAccess,
        Custom,
    }
}
