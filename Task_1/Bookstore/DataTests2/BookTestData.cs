using System.Collections;
using System.Collections.Generic;
using Data;

namespace DataTests
{
    public class BookTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Description("The Final Empire", "Brandon Sanderson"), 8.99f };
            yield return new object[] { new Description("Ostatnie Życzenie", "Andrzej Sapkowski"), 7.99f };
            yield return new object[] { new Description("Harry Potter and the Philosopher's Stone", "J.K. Rowling"), 7.49f };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
