// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the order hints for each assignee's column in "assigned to" task board for the containing <see cref="PlannerTask"/>. 
    /// </summary>
    public partial class PlannerOrderHintsByAssignee : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Gets or sets the order hint of an assignee.
        /// </summary>
        /// <param name="userId">User id of the assignee.</param>
        /// <returns>The order hint.</returns>
        [JsonIgnore]
        public string this[string userId]
        {
            get
            {
                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                return this.AdditionalData.TryGetValue(userId, out object orderHint) ? orderHint.ToString() : null;
            }

            set
            {
                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                this.AdditionalData[userId] = value;
            }
        }

        /// <summary>
        /// Returns pairs of assignee user ids and the corresponding order hint for the assignee's column.
        /// </summary>
        /// <returns>Enumeration of user id, order hint pairs.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            return this.AdditionalData
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value.ToString()) && kvp.Key != CoreConstants.Serialization.ODataType)
                .Select(kvp => new KeyValuePair<string, string>(kvp.Key, (string)kvp.Value))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
