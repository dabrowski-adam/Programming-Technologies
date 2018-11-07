using System.Collections.Generic;
using System.Linq;
using Xunit;
using Logic;
using Data;

namespace LogicTests
{
    public class StoreTest
    {
        #region GetEvents
        [Fact]
        public void GetEventsTest() {
            var history = new List<Event>
            {
                new Event(new Actor("John Smith"), new List<Invoice> { new Invoice(new ISBN("1"), 50f, 2) }),
                new Event(new Actor("Larry Page"), new List<Invoice> { new Invoice(new ISBN("2"), 24.99f, 15) })
            };
            Store store = new Store(new Catalog(), new Inventory(), history, .0f);
            Assert.Equal(history, store.GetEvents());
        }
        #endregion

        #region GetBooks
        [Fact]
        public void GetBooksTest()
        {
            var catalog = new Catalog
            {
                { new ISBN("1234567890123"), new Book(new Description("Title", "Author"), 24.99f) },
                { new ISBN("1234567890000"), new Book(new Description("Another Title", "Author"), 4.99f) }
            };
            Store store = new Store(catalog, new Inventory(), new List<Event>(), .0f);
            Assert.Equal(catalog.Keys, store.GetBooks());
        }
        #endregion

        #region GetBookListing
        [Fact]
        public void GetBookListingTest()
        {
            string id = "1234567890123";
            Book book = new Book(new Description("Title", "Author"), 24.99f);

            var catalog = new Catalog();
            catalog.Add(new ISBN(id), book);

            Store store = new Store(catalog, new Inventory(), new List<Event>(), .0f);
            Assert.Equal(book, store.GetBookListing(new ISBN(id)));
        }
        #endregion

        #region GetBookDescription
        [Fact]
        public void GetBookDescriptionTest()
        {
            string id = "1234567890123";
            Description description = new Description("Title", "Author");

            var catalog = new Catalog();
            catalog.Add(new ISBN(id), new Book(description, 24.99f));

            Store store = new Store(catalog, new Inventory(), new List<Event>(), .0f);
            Assert.Equal(description, store.GetBookDescription(new ISBN(id)));
        }
        #endregion

        #region GetBookAvailability
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(999)]
        public void GetBookAvailabilityTest(int number)
        {
            string id = "1234567890123";

            var catalog = new Catalog();
            catalog.Add(new ISBN(id), new Book(new Description("Title", "Author"), 24.99f));

            var inventory = new Inventory();
            inventory.Add(new ISBN(id), number);

            Store store = new Store(catalog, inventory, new List<Event>(), .0f);
            Assert.Equal(number, store.GetBookAvailability(new ISBN(id)));
        }
        #endregion

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

        #region SuccessfulSale
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndPossibleSales), MemberType = typeof(StoreTestData))]
        public void SuccessfulSale(Store store, Actor buyer, ISBN isbn, int count)
        {
            var events = store.GetEvents();

            int eventCount = events.Count();
            int bookCount = store.GetBookAvailability(isbn);
            float capital = store.Money;

            Assert.True(store.Sell(buyer, isbn, count));

            // Check event logging
            Assert.Equal(eventCount + 1, events.Count());

            Event sale = events.Last();
            Assert.Equal(buyer.Name, sale.Actor.Name);

            var invoices = sale.Invoices;
            Assert.Single(invoices);

            Invoice invoice = invoices.ElementAt(0);
            Assert.Equal(isbn, invoice.ISBN);
            Assert.Equal(store.GetBookListing(isbn).Price, invoice.Price);
            Assert.Equal(count, invoice.Number);

            // Check inventory
            Assert.Equal(bookCount - count, store.GetBookAvailability(isbn));
        }
        #endregion

        #region UnsuccessfulSale
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndImpossibleSales), MemberType = typeof(StoreTestData))]
        public void UnsuccessfulSale(Store store, Actor buyer, ISBN isbn, int count)
        {
            var events = store.GetEvents();

            int eventCount = events.Count();
            int bookCount = store.GetBookAvailability(isbn);
            float capital = store.Money;

            Assert.False(store.Sell(buyer, isbn, count));
            Assert.Equal(capital, store.Money);
            Assert.Equal(eventCount, events.Count());
            Assert.Equal(bookCount, store.GetBookAvailability(isbn));
        }
        #endregion
    }
}
