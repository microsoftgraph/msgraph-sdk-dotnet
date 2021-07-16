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
    /// Represents a collection of user ids.
    /// </summary>
    public partial class PlannerUserIds : IEnumerable<string>
    {
        /// <summary>
        /// Number of user ids in the collection.
        /// </summary>
        [JsonIgnore]
        public int Count => this.UserIds.Count();

        /// <summary>
        /// Adds a user id to the collection.
        /// </summary>
        /// <param name="userId">User id to add.</param>
        public void Add(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            this.AdditionalData[userId] = true;
        }

        /// <summary>
        /// Removes a user id from the collection.
        /// </summary>
        /// <param name="userId">User id to remove.</param>
        public void Remove(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            this.AdditionalData[userId] = false;
        }

        /// <summary>
        /// Checks if a given user id is present in the collection.
        /// </summary>
        /// <param name="userId">User id to check</param>
        /// <returns>True if the user is is present in the collection, false otherwise.</returns>
        public bool Contains(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            return this.AdditionalData.TryGetValue(userId, out object value) && value is bool boolValue && boolValue;
        }

        /// <summary>
        /// Returns the user ids in the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
        {
            return this.UserIds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<string> UserIds
        {
            get
            {
                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                return this.AdditionalData.Where(kvp => kvp.Value is bool).Select(kvp => kvp.Key);
            }
        }
    }
}
