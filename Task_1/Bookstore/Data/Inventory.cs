using System.Collections;
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// The Inventory class handles management of current stock.
    /// </summary>
    public class Inventory : IDictionary<ISBN, int>
    {
        private Dictionary<ISBN, int> data;

        public Inventory() {
            this.data = new Dictionary<ISBN, int>();
        }

        public int this[ISBN key] { get => this.data[key]; set { this.data[key] = value; } }

        public ICollection<ISBN> Keys => this.data.Keys;

        public ICollection<int> Values => this.data.Values;

        public int Count => this.data.Count;

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Remove(ISBN key, int value) {
            if (this.data.ContainsKey(key) && this.data[key] >= value) {
                this.data[key] -= value;
            } else {
                throw new System.ArgumentOutOfRangeException(nameof(value));
            }
        }

        public void Add(ISBN key, int value)
        {
            if (this.data.ContainsKey(key)) {
                this.data[key] += value;
            } else {
                this.data.Add(key, value);
            }
        }

        public void Add(KeyValuePair<ISBN, int> item)
        {
            this.data.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public bool Contains(KeyValuePair<ISBN, int> item) => throw new System.NotImplementedException();

        public bool ContainsKey(ISBN key) => this.data.ContainsKey(key);

        public void CopyTo(KeyValuePair<ISBN, int>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<ISBN, int>> GetEnumerator() => this.data.GetEnumerator();

        public bool Remove(ISBN key) => this.data.Remove(key);

        public bool Remove(KeyValuePair<ISBN, int> item) => this.data.Remove(item.Key);

        public bool TryGetValue(ISBN key, out int value) => this.data.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => this.data.GetEnumerator();
    }
}
