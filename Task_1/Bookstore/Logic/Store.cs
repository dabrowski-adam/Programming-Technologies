using Data;

namespace Logic
{
    /// <summary>
    /// The Store class contains methods for stocking and selling books.
    /// </summary>
    public class Store
    {
        public void Buy(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }

        public void Stock(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }
    }
}
