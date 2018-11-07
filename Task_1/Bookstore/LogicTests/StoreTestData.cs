using System.Collections;
using System.Collections.Generic;
using Logic;

namespace LogicTests
{
    public class StoreTestData : IEnumerable<object[]>
    {
        StoreFactory storeFactory = new StoreFactory();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { storeFactory.CreateStore(.0f) };
            yield return new object[] { storeFactory.CreateStore(1000f) };
            yield return new object[] { storeFactory.CreateStore(1000000f) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
