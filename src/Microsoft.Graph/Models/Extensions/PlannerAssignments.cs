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
    /// Represents assignments of a <see cref="PlannerTask"/>.
    /// </summary>
    public partial class PlannerAssignments : IEnumerable<KeyValuePair<string, PlannerAssignment>>
    {
        /// <summary>
        /// Gets the ids of the users assigned to the task. 
        /// </summary>
        [JsonIgnore]
        public IEnumerable<string> Assignees
        {
            get
            {
                EnsureDeserializedAssignments();
                return this.AdditionalData.Where(kvp => kvp.Value is PlannerAssignment).Select(kvp => kvp.Key);
            }
        }

        /// <summary>
        /// Gets the number of assignees on the task.
        /// </summary>
        [JsonIgnore]
        public int Count => this.Assignees.Count();

        /// <summary>
        /// Gets or sets assignment data for a user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The assignment information for the given assignee.</returns>
        [JsonIgnore]
        public PlannerAssignment this[string userId]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new ArgumentNullException(nameof(userId));
                }

                EnsureDeserializedAssignments();

                if (!this.AdditionalData.TryGetValue(userId, out object assignmentObject))
                {
                    return null;
                }

                return assignmentObject as PlannerAssignment;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new ArgumentNullException(nameof(userId));
                }

                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                this.AdditionalData[userId] = value;
            }
        }

        /// <summary>
        /// Assigns the task to the user with the given id.
        /// </summary>
        /// <param name="userId">Id of the user to assign the task.</param>
        public void AddAssignee(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var plannerAssignment = new PlannerAssignment();

            // Use default sorting.
            plannerAssignment.OrderHint = " !";

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            this.AdditionalData.Add(userId, plannerAssignment);
        }

        /// <summary>
        /// Returns pairs of user ids and their assignment information for users that are assigned to the task.
        /// </summary>
        /// <returns>Enumeration of user id, assignment information pairs.</returns>
        public IEnumerator<KeyValuePair<string, PlannerAssignment>> GetEnumerator()
        {
            EnsureDeserializedAssignments();

            return this.AdditionalData
                .Where(kvp => kvp.Value is PlannerAssignment)
                .Select(kvp => new KeyValuePair<string, PlannerAssignment>(kvp.Key, (PlannerAssignment)kvp.Value))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Ensures the Assignment information is deserialized into <see cref="PlannerAssignment"/> objects.
        /// </summary>
        internal void EnsureDeserializedAssignments()
        {
            this.AdditionalData ??= new Dictionary<string, object>();

            this.AdditionalData.ConvertComplexTypeProperties<PlannerAssignment>(PlannerAssignment.ODataTypeName);
        }
    }
}
