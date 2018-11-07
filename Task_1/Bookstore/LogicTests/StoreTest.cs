using Xunit;
using Logic;

namespace LogicTests
{
    public class StoreTest
    {
        [Theory]
        [ClassData(typeof(StoreTestData))]
        public void StockTest(Store store)
        {
            Assert.True(true);
        }
    }
}
