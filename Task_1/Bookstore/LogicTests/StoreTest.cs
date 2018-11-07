using System.Linq;
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

            var events = store.GetEvents();
            Assert.Single(events);

            var buy = events.ElementAt(0);
            Assert.Equal(seller.Name, buy.Actor.Name);

            var invoices = buy.Invoices;
            Assert.Single(invoices);

            var invoice = invoices.ElementAt(0);
            Assert.Equal(isbn, invoice.ISBN);
            Assert.Equal(price, invoice.Price);
            Assert.Equal(count, invoice.Number);
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
            Assert.Empty(store.GetEvents());
        }
        #endregion
    }
}
