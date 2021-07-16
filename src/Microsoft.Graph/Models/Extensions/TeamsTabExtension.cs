namespace Microsoft.Graph
{
    using System.Text.Json.Serialization;
    public partial class TeamsTab 
    {
        /// <summary>
        /// Gets or sets an associated existing app with a teams tab.
        /// </summary>
        [JsonPropertyName("teamsApp@odata.bind")]
        public string ODataBind { get; set; }

    }
}
