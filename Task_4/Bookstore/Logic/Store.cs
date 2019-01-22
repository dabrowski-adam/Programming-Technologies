using System.Collections.Generic;
using System.Linq;
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
        readonly ICatalog catalog;
        readonly IInventory inventory;
        readonly IHistory history;

        public Store(ICatalog catalog, IInventory inventory, IHistory history, float capital)
        {
            Money = capital;
            this.catalog = catalog;
            this.inventory = inventory;
            this.history = history;
        }

        public IEnumerable<IEvent> GetEvents() {
            return history.Events;
        }

        public IEnumerable<IBook> GetBooks() {
            return catalog.Keys.ToList();
        }

        public IDescription GetBookListing(IBook book)
        {
            return catalog.TryGetValue(book, out IDescription description) ? description : null;
        }

        public uint GetBookAvailability(IBook book)
        {
            return inventory.State.TryGetValue(book, out uint count) ? count : 0;
        }

        public bool Stock(IActor seller, float price, uint count, IBook book, IDescription description)
        {
            // Check if there's enough money to pay for this shipment
            if (Money < price * count) { return false; }

            Money -= price * count;

            // Ensure the book is listed in the catalog
            if (!catalog.ContainsKey(book))
            {
                description.Price = price + price * PROFIT_MARGIN; // Change from MSRP to actual price
                catalog.Add(book, description);
            }

            // Update stock count
            IInvoice invoice = inventory.Stock(book, price, count);

            // Log the delivery
            history.LogStock(seller, invoice);

            return true;
        }

        public bool Sell(IActor customer, IBook book, uint count)
        {
            uint inStock = GetBookAvailability(book);
            if (count == 0 || inStock < count) { return false; }

            float price = catalog[book].Price;
            Money += price * count;

            // Update stock count
            IInvoice invoice = inventory.Sell(book, price, count);

            // Log the sale
            history.LogSale(customer, invoice);

            // Remove from catalog if no longer available
            if (inStock - count == 0)
            {
                catalog.Remove(book);
            }

            return true;
        }
    }
}
