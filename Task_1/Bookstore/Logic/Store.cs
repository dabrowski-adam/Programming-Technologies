using System.Collections.Generic;
using Data;

namespace Logic
{
    /// <summary>
    /// The Store class contains methods for stocking and selling books.
    /// </summary>
    public class Store
    {
        private readonly Catalog catalog;
        private readonly Inventory inventory;
        private readonly List<Event> history;

        public Store(Catalog catalog, Inventory inventory) {
            this.catalog = catalog;
            this.inventory = inventory;
            history = new List<Event>();
        }

        public void Stock(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }

        public void Sell(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }
    }
}
