using System.Collections;
using System.Collections.Generic;
using Data;

namespace LogicTests
{
    internal static class CatalogGenerator
    {
        internal static ICatalog PrepareData()
        {
            return new Catalog();
        }

        private class Catalog : ICatalog
        {
            private readonly Dictionary<IBook, IDescription> data;

            public Catalog()
            {
                data = new Dictionary<IBook, IDescription>();
            }

            public IDescription this[IBook key] { get => data[key]; set { data[key] = value; } }

            public ICollection<IBook> Keys => data.Keys;

            public ICollection<IDescription> Values => data.Values;

            public int Count => data.Count;

            public bool IsReadOnly => throw new System.NotImplementedException();

            public void Add(IBook key, IDescription value)
            {
                data.Add(key, value);
            }

            public void Add(KeyValuePair<IBook, IDescription> item)
            {
                data.Add(item.Key, item.Value);
            }

            public void Clear()
            {
                data.Clear();
            }

            public bool Contains(KeyValuePair<IBook, IDescription> item) => throw new System.NotImplementedException();

            public bool ContainsKey(IBook key) => data.ContainsKey(key);

            public void CopyTo(KeyValuePair<IBook, IDescription>[] array, int arrayIndex)
            {
                throw new System.NotImplementedException();
            }

            public IEnumerator<KeyValuePair<IBook, IDescription>> GetEnumerator() => data.GetEnumerator();

            public bool Remove(IBook key) => data.Remove(key);

            public bool Remove(KeyValuePair<IBook, IDescription> item) => data.Remove(item.Key);

            public bool TryGetValue(IBook key, out IDescription value)
            {
                return data.TryGetValue(key, out value);
            }

            IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
        }

    }
}
