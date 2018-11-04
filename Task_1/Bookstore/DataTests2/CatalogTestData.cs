using System.Collections;
using System.Collections.Generic;
using Data;

namespace DataTests
{
    public class CatalogTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ISBN("9780765311788"), new Book("The Final Empire", "Brandon Sanderson") };
            yield return new object[] { new ISBN("9788370540616"), new Book("Ostatnie Życzenie", "Andrzej Sapkowski") };
            yield return new object[] { new ISBN("9780439554930"), new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling") };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
