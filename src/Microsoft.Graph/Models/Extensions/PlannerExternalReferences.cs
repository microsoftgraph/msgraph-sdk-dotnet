// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the external references on a <see cref="PlannerTaskDetails"/>.
    /// </summary>
    public partial class PlannerExternalReferences : IEnumerable<KeyValuePair<string, PlannerExternalReference>>
    {
        /// <summary>
        /// Specifies the character - encoding pairs to apply on the external reference urls.
        /// </summary>
        private static readonly string[,] Conversions = new string[,] { { "%", "%25" }, { "@", "%40" }, { ".", "%2E" }, { ":", "%3A" } };

        /// <summary>
        /// Gets or sets external reference data for a given reference url.
        /// </summary>
        /// <param name="url">The url of the reference.</param>
        /// <returns>The external reference data for the given url.</returns>
        [JsonIgnore]
        public PlannerExternalReference this[string url]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException(nameof(url));
                }

                EnsureDeserializedReferences();

                if (!this.AdditionalData.TryGetValue(Encode(url), out object referenceObject))
                {
                    return null;
                }

                return referenceObject as PlannerExternalReference;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentNullException(nameof(url));
                }

                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                this.AdditionalData[Encode(url)] = value;
            }
        }

        /// <summary>
        /// Adds a new external reference with the given url and short name.
        /// </summary>
        /// <param name="url">Url of the external reference.</param>
        /// <param name="alias">Short name for the external reference.</param>
        /// <returns>The created external reference.</returns>
        public PlannerExternalReference AddReference(string url, string alias)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentNullException(nameof(alias));
            }

            var plannerExternalReference = new PlannerExternalReference();

            plannerExternalReference.Alias = alias;

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            this.AdditionalData.Add(Encode(url), plannerExternalReference);

            return plannerExternalReference;
        }

        /// <summary>
        /// Returns pairs of external reference urls and external reference data.
        /// </summary>
        /// <returns>Enumeration of external reference ulr, external reference data pairs.</returns>
        public IEnumerator<KeyValuePair<string, PlannerExternalReference>> GetEnumerator()
        {
            EnsureDeserializedReferences();

            return this.AdditionalData
               .Where(kvp => kvp.Value is PlannerExternalReference)
               .Select(kvp => new KeyValuePair<string, PlannerExternalReference>(Decode(kvp.Key), (PlannerExternalReference)kvp.Value))
               .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Ensures the ExternalReference information is deserialized into <see cref="PlannerExternalReference"/> objects.
        /// </summary>
        internal void EnsureDeserializedReferences()
        {
            this.AdditionalData ??= new Dictionary<string, object>();

            this.AdditionalData.ConvertComplexTypeProperties<PlannerExternalReference>(PlannerExternalReference.ODataTypeName);
        }

        /// <summary>
        /// Encodes the url of an external reference to be compatible with a OData property naming requirements.
        /// </summary>
        /// <param name="externalReferenceUrl">Url to encode</param>
        /// <returns>Encoded Url</returns>
        private static string Encode(string externalReferenceUrl)
        {
            if (string.IsNullOrEmpty(externalReferenceUrl))
            {
                throw new ArgumentNullException(nameof(externalReferenceUrl));
            }

            for (int i = 0; i < Conversions.GetLength(0); i++)
            {
                externalReferenceUrl = externalReferenceUrl.Replace(Conversions[i, 0], Conversions[i, 1]);
            }

            return externalReferenceUrl;
        }

        /// <summary>
        /// Decodes an encoded the url of an external reference.
        /// </summary>
        /// <param name="externalReferenceUrl">Url to decode</param>
        /// <returns>Decoded Url</returns>
        private static string Decode(string externalReferenceUrl)
        {
            if (string.IsNullOrEmpty(externalReferenceUrl))
            {
                throw new ArgumentNullException(nameof(externalReferenceUrl));
            }

            for (int i = Conversions.GetLength(0) - 1; i >= 0; i--)
            {
                externalReferenceUrl = externalReferenceUrl.Replace(Conversions[i, 1], Conversions[i, 0]);
            }

            return externalReferenceUrl;
        }
    }
}
