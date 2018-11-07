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

            // Check event logging
            var events = store.GetEvents();
            Assert.Single(events);

            Event buy = events.ElementAt(0);
            Assert.Equal(seller.Name, buy.Actor.Name);

            var invoices = buy.Invoices;
            Assert.Single(invoices);

            Invoice invoice = invoices.ElementAt(0);
            Assert.Equal(isbn, invoice.ISBN);
            Assert.Equal(price, invoice.Price);
            Assert.Equal(count, invoice.Number);

            // Check catalog
            var books = store.GetBooks();
            Assert.Single(books);

            ISBN addedISBN = books.ElementAt(0);
            Assert.Equal(isbn, addedISBN);

            Description addedDescription = store.GetBookDescription(addedISBN);
            Assert.Equal(description.Author, addedDescription.Author);
            Assert.Equal(description.Title, addedDescription.Title);

            // Check inventory
            int addedCount = store.GetBookAvailability(addedISBN);
            Assert.Equal(count, addedCount);
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

            // Check event logging
            var events = store.GetEvents();
            Assert.Empty(events);

            // Check catalog
            var books = store.GetBooks();
            Assert.Empty(books);
            Assert.Null(store.GetBookDescription(isbn));

            // Check inventory
            Assert.Equal(0, store.GetBookAvailability(isbn));
        }
        #endregion
    }
}
