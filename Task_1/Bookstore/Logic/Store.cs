using System.Collections.Generic;
using Data;

namespace Logic
{
    /// <summary>
    /// The Store class contains methods for stocking and selling books.
    /// </summary>
    public class Store
    {
        public float Money { get; private set; }
        const float PROFIT_MARGIN = 0.2f;
        readonly Catalog catalog;
        readonly Inventory inventory;
        readonly List<Event> history;

        public Store(Catalog catalog, Inventory inventory, float capital) {
            Money = capital;
            this.catalog = catalog;
            this.inventory = inventory;
            history = new List<Event>();
        }

        public bool Stock(Actor seller, float price, int count, ISBN isbn, Description description)
        {
            // Check if there's enough money to pay for this shipment
            if (Money < price * count) { return false; }

            // Log the delivery
            Invoice invoice = new Invoice(isbn, price, count);
            Event delivery = new Event(seller, new List<Invoice> { invoice });

            // Ensure the book is listed in the catalog
            if (!catalog.ContainsKey(isbn)) {
                Book book = new Book(description, price + price * PROFIT_MARGIN);
                catalog.Add(isbn, book);
            }

            // Update stock count
            inventory.Add(isbn, count);

            return true;
        }

        public void Sell(ISBN book, int amount)
        {

        }
    }
}
