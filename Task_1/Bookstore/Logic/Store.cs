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

        public Store(Catalog catalog, Inventory inventory, List<Event> history, float capital) {
            Money = capital;
            this.catalog = catalog;
            this.inventory = inventory;
            this.history = history;
        }

        public bool Stock(Actor seller, float price, int count, ISBN isbn, Description description)
        {
            // Check if there's enough money to pay for this shipment
            if (Money < price * count) { return false; }

            Money -= price * count;

            // Log the delivery
            Invoice invoice = new Invoice(isbn, price, count);
            Event delivery = new Event(seller, new List<Invoice> { invoice });
            history.Add(delivery);

            // Ensure the book is listed in the catalog
            if (!catalog.ContainsKey(isbn)) {
                Book book = new Book(description, price + price * PROFIT_MARGIN);
                catalog.Add(isbn, book);
            }

            // Update stock count
            inventory.Add(isbn, count);

            return true;
        }

        public bool Sell(Actor customer, ISBN isbn, int count)
        {
            int inStock = inventory[isbn];
            if (inStock < count) { return false; }

            float price = catalog[isbn].Price;
            Invoice invoice = new Invoice(isbn, price, count);
            Event sale = new Event(customer, new List<Invoice> { invoice });
            history.Add(sale);

            Money += price * count;

            inventory.Remove(isbn, count);

            return true;
        }
    }
}
