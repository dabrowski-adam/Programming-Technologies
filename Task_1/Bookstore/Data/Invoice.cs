namespace Data
{
    public class Invoice
    {
        public Book Book { get; private set; }
        public float Price { get; private set; }
        public int amount { get; private set; }

        public Invoice(Book book, float price, int amount)
        {
            this.Book = book;
            this.amount = amount;
            this.Price = price;
        }
    }
}