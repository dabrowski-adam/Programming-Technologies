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
            float capital = store.Money;
            Assert.True(store.Stock(seller, price, count, isbn, description));
            Assert.Equal(capital - price * count, store.Money);
        }
        #endregion

        #region UnsuccessfulStocking
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndTooExpensiveDeliveries), MemberType = typeof(StoreTestData))]
        public void StockTooExpensiveTest(Store store, Actor seller, float price, int count, ISBN isbn, Description description)
        {
            float capital = store.Money;
            Assert.False(store.Stock(seller, price, count, isbn, description));
            Assert.Equal(capital, store.Money);
        }
        #endregion
    }
}
