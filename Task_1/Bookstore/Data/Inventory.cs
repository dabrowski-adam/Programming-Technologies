using System.Collections;
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// The Inventory class handles management of current stock.
    /// </summary>
    public class Inventory : IDictionary<ISBN, int>
    {
        private readonly Dictionary<ISBN, int> data;

        public Inventory()
        {
            data = new Dictionary<ISBN, int>();
        }

        public int this[ISBN key] { get => data[key]; set { data[key] = value; } }

        public ICollection<ISBN> Keys => data.Keys;

        public ICollection<int> Values => data.Values;

        public int Count => data.Count;

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Remove(ISBN key, int value)
        {
            if (data.ContainsKey(key))
            {
                int count = data[key];

                if (count > value) {
                    data[key] -= value;
                } else if (count == value) {
                    data.Remove(key);
                } else {
                    throw new System.ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public void Add(ISBN key, int value)
        {
            if (data.ContainsKey(key))
            {
                data[key] += value;
            }
            else
            {
                data.Add(key, value);
            }
        }

        public void Add(KeyValuePair<ISBN, int> item)
        {
            data.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(KeyValuePair<ISBN, int> item) => throw new System.NotImplementedException();

        public bool ContainsKey(ISBN key) => data.ContainsKey(key);

        public void CopyTo(KeyValuePair<ISBN, int>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<ISBN, int>> GetEnumerator() => data.GetEnumerator();

        public bool Remove(ISBN key) => data.Remove(key);

        public bool Remove(KeyValuePair<ISBN, int> item) => data.Remove(item.Key);

        public bool TryGetValue(ISBN key, out int value) => data.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
    }
}
