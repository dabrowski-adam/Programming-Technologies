using System.Collections.Generic;
using System.Linq;
using Xunit;
using Logic;
using Data;

namespace LogicTests
{
    public class StoreTest
    {
        #region GetBooks
        [Fact]
        public void GetBooksTest()
        {
            ICatalog catalog = CatalogGenerator.PrepareData();

            IBook book = BookDataGenerator.PrepareData().First();
            IDescription description = DescriptionDataGenerator.PrepareData().First();

            IBook book2 = BookDataGenerator.PrepareData().Last();
            IDescription description2 = DescriptionDataGenerator.PrepareData().Last();

            catalog.Add(book, description);
            catalog.Add(book2, description2);

            IInventory inventory = InventoryGenerator.PrepareData();
            IHistory history = HistoryGenerator.PrepareData();

            Store store = new Store(catalog, inventory, history, .0f);
            Assert.Equal(catalog.Keys, store.GetBooks());
        }
        #endregion

        #region GetBookListing
        [Fact]
        public void GetBookListingTest()
        {
            IBook book = BookDataGenerator.PrepareData().First();
            IDescription description = DescriptionDataGenerator.PrepareData().First();

            ICatalog catalog = CatalogGenerator.PrepareData();
            catalog.Add(book, description);

            IInventory inventory = InventoryGenerator.PrepareData();
            IHistory history = HistoryGenerator.PrepareData();
            Store store = new Store(catalog, inventory, history, .0f);
            Assert.Equal(description, store.GetBookListing(book));
        }
        #endregion

        #region GetBookAvailability
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(999)]
        public void GetBookAvailabilityTest(uint number)
        {
            IBook book = BookDataGenerator.PrepareData().First();
            IDescription description = DescriptionDataGenerator.PrepareData().First();

            var catalog = CatalogGenerator.PrepareData();
            catalog.Add(book, description);

            var inventory = InventoryGenerator.PrepareData();
            inventory.State.Add(book, number);

            IHistory history = HistoryGenerator.PrepareData();
            Store store = new Store(catalog, inventory, history, .0f);
            Assert.Equal(number, store.GetBookAvailability(book));
        }
        #endregion

        #region SuccessfulStocking
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndAffordableDeliveries), MemberType = typeof(StoreTestData))]
        public void StockTest(Store store, IActor seller, float price, uint count, IBook book, IDescription description)
        {
            float capital = store.Money;
            Assert.True(store.Stock(seller, price, count, book, description));
            Assert.Equal(capital - price * count, store.Money);

            // Check event logging
            var events = store.GetEvents();
            Assert.Single(events);

            IEvent buy = events.ElementAt(0);
            Assert.Equal(seller.Name, buy.Actor.Name);

            var invoices = buy.Invoices;
            Assert.Single(invoices);

            IInvoice invoice = invoices.ElementAt(0);
            Assert.Equal(book, invoice.Book);
            Assert.Equal(price, invoice.Price);
            Assert.Equal(count, (uint)invoice.Number);

            // Check catalog
            var books = store.GetBooks();
            Assert.Single(books);

            IBook addedBook = books.ElementAt(0);
            Assert.Equal(book, addedBook);

            IDescription addedDescription = store.GetBookListing(addedBook);
            Assert.Equal(description.Author, addedDescription.Author);
            Assert.Equal(description.Title, addedDescription.Title);

            // Check inventory
            uint addedCount = store.GetBookAvailability(addedBook);
            Assert.Equal(count, addedCount);
        }
        #endregion

        #region UnsuccessfulStocking
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndTooExpensiveDeliveries), MemberType = typeof(StoreTestData))]
        public void StockTooExpensiveTest(Store store, IActor seller, float price, uint count, IBook book, IDescription description)
        {
            float capital = store.Money;
            Assert.False(store.Stock(seller, price, count, book, description));
            Assert.Equal(capital, store.Money);

            // Check event logging
            var events = store.GetEvents();
            Assert.Empty(events);

            // Check catalog
            var books = store.GetBooks();
            Assert.Empty(books);
            Assert.Null(store.GetBookListing(book));

            // Check inventory
            Assert.Equal((uint)0, store.GetBookAvailability(book));
        }
        #endregion

        #region SuccessfulSale
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndPossibleSales), MemberType = typeof(StoreTestData))]
        public void SuccessfulSale(Store store, IActor buyer, IBook book, uint count)
        {
            var events = store.GetEvents();

            int eventCount = events.Count();
            uint bookCount = store.GetBookAvailability(book);
            float capital = store.Money;

            Assert.True(store.Sell(buyer, book, count));

            // Check event logging
            Assert.Equal(eventCount + 1, events.Count());

            IEvent sale = events.Last();
            Assert.Equal(buyer.Name, sale.Actor.Name);

            var invoices = sale.Invoices;
            Assert.Single(invoices);

            IInvoice invoice = invoices.ElementAt(0);
            Assert.Equal(book, invoice.Book);
            Assert.Equal(store.GetBookListing(book).Price, invoice.Price);
            Assert.Equal(count, (uint)invoice.Number);

            // Check inventory
            Assert.Equal(bookCount - count, store.GetBookAvailability(book));
        }
        #endregion

        #region UnsuccessfulSale
        [Theory]
        [MemberData(nameof(StoreTestData.GetStoresAndImpossibleSales), MemberType = typeof(StoreTestData))]
        public void UnsuccessfulSale(Store store, IActor buyer, IBook book, uint count)
        {
            var events = store.GetEvents();

            int eventCount = events.Count();
            uint bookCount = store.GetBookAvailability(book);
            float capital = store.Money;

            Assert.False(store.Sell(buyer, book, count));
            Assert.Equal(capital, store.Money);
            Assert.Equal(eventCount, events.Count());
            Assert.Equal(bookCount, store.GetBookAvailability(book));
        }
        #endregion
    }
}
