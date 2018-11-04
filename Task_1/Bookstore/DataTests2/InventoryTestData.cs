using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Data;
using System.Collections;

namespace DataTests
{
    public class InventoryTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ISBN("9780765311788"), 3 };
            yield return new object[] { new ISBN("9788370540616"), 4 };
            yield return new object[] { new ISBN("9780439554930"), 10 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
