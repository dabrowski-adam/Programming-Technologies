namespace Data
{
    public class Invoice
    {
        public Book Book { get; private set; }
        public float Price { get; private set; }
        public int Amount { get; private set; }

        public Invoice(Book book, float price, int amount)
        {
            this.Book = book;
            this.Amount = amount;
            this.Price = price;
        }
    }
}