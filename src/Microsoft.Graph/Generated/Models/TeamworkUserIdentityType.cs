namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum TeamworkUserIdentityType {
        AadUser,
        OnPremiseAadUser,
        AnonymousGuest,
        FederatedUser,
        PersonalMicrosoftAccountUser,
        SkypeUser,
        PhoneUser,
        UnknownFutureValue,
        EmailUser,
    }
}
