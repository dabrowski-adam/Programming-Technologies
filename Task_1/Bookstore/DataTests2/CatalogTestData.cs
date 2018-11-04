using System.Collections;
using System.Collections.Generic;
using Data;

namespace DataTests
{
    public class CatalogTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ISBN("9780765311788"), new Book(new Description("The Final Empire", "Brandon Sanderson"), 8.99f) };
            yield return new object[] { new ISBN("9788370540616"), new Book(new Description("Ostatnie Życzenie", "Andrzej Sapkowski"), 7.99f) };
            yield return new object[] { new ISBN("9780439554930"), new Book(new Description("Harry Potter and the Philosopher's Stone", "J.K. Rowling"), 7.49f) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
