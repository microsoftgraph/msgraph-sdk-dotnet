// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core
{
    using System.Collections.Generic;

    public class CollectionPage<T> : ICollectionPage<T>
    {
        public CollectionPage()
        {
            this.CurrentPage = new List<T>();
        }

        public CollectionPage(IList<T> currentPage)
        {
            this.CurrentPage = currentPage;
        }

        public IList<T> CurrentPage { get; private set; }

        public int IndexOf(T item)
        {
            return this.CurrentPage.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.CurrentPage.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.CurrentPage.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return this.CurrentPage[index]; }
            set { this.CurrentPage[index] = value; }
        }

        public void Add(T item)
        {
            this.CurrentPage.Add(item);
        }

        public void Clear()
        {
            this.CurrentPage.Clear();
        }

        public bool Contains(T item)
        {
            return this.CurrentPage.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.CurrentPage.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.CurrentPage.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.CurrentPage.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return this.CurrentPage.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.CurrentPage.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.CurrentPage.GetEnumerator();
        }

        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
