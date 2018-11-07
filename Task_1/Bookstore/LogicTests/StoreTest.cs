using Xunit;
using Logic;
using Data;

namespace LogicTests
{
    public class StoreTest
    {
        #region SuccessfulStocking
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndAffordableDeliveries), MemberType = typeof(StoreTestData))]
        public void StockTest(Store store, Actor seller, float price, int count, ISBN isbn, Description description)
        {
            Assert.True(store.Stock(seller, price, count, isbn, description));
        }
        #endregion
    }
}
