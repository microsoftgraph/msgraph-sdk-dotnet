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
    /// Represents the checklist on a <see cref="PlannerTaskDetails"/>. 
    /// </summary>
    public partial class PlannerChecklistItems : IEnumerable<KeyValuePair<string, PlannerChecklistItem>>
    {
        /// <summary>
        /// Gets or sets checklist item data for a given checklist item id.
        /// </summary>
        /// <param name="checklistItemId">The id of the checklit item.</param>
        /// <returns>The checklist item for the given checklist item id.</returns>
        [JsonIgnore]
        public PlannerChecklistItem this[string checklistItemId]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(checklistItemId))
                {
                    throw new ArgumentNullException(nameof(checklistItemId));
                }

                EnsureDeserializedChecklist();

                if (!this.AdditionalData.TryGetValue(checklistItemId, out object checklistItemObject))
                {
                    return null;
                }

                return checklistItemObject as PlannerChecklistItem;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(checklistItemId))
                {
                    throw new ArgumentNullException(nameof(checklistItemId));
                }

                if (this.AdditionalData is null)
                {
                    this.AdditionalData = new Dictionary<string, object>();
                }

                this.AdditionalData[checklistItemId] = value;
            }
        }

        /// <summary>
        /// Creates a new checklist item with the given title.
        /// </summary>
        /// <param name="title">Title of the checklist item.</param>
        /// <returns>The id of the checklist item.</returns>
        public string AddChecklistItem(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            var plannerChecklistItem = new PlannerChecklistItem();

            plannerChecklistItem.Title = title;
            var newChecklistItemId = Guid.NewGuid().ToString();

            if (this.AdditionalData is null)
            {
                this.AdditionalData = new Dictionary<string, object>();
            }

            this.AdditionalData.Add(newChecklistItemId, plannerChecklistItem);

            return newChecklistItemId;
        }

        /// <summary>
        /// Returns pairs of checklist item ids and checklist items.
        /// </summary>
        /// <returns>Enumeration of checklist item id, checklist item pairs.</returns>
        public IEnumerator<KeyValuePair<string, PlannerChecklistItem>> GetEnumerator()
        {
            EnsureDeserializedChecklist();

            return this.AdditionalData
                .Where(kvp => kvp.Value is PlannerChecklistItem)
                .Select(kvp => new KeyValuePair<string, PlannerChecklistItem>(kvp.Key, (PlannerChecklistItem)kvp.Value))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Ensures the ChecklistItem information is deserialized into <see cref="PlannerChecklistItem"/> objects.
        /// </summary>
        internal void EnsureDeserializedChecklist()
        {
            this.AdditionalData ??= new Dictionary<string, object>();

            this.AdditionalData.ConvertComplexTypeProperties<PlannerChecklistItem>(PlannerChecklistItem.ODataTypeName);
        }
    }
}
