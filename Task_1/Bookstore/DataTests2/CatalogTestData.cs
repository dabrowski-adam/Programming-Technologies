using System.Collections;
using System.Collections.Generic;
using Data;

namespace DataTests
{
    public class CatalogTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Book("The Final Empire", "Brandon Sanderson") };
            yield return new object[] { new Book("Ostatnie Życzenie", "Andrzej Sapkowski") };
            yield return new object[] { new Book("Harry Potter and the Philosopher's Stone", "J.K. Rowling") ;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
