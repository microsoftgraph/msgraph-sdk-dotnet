namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum FileHashType {
        Unknown,
        Sha1,
        Sha256,
        Md5,
        AuthenticodeHash256,
        LsHash,
        Ctph,
        UnknownFutureValue,
    }
}
