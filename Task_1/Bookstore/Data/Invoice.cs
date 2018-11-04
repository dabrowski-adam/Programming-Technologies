namespace Data
{
    public class Invoice
    {
        public Book Book { get; private set; }
        public float Price { get; private set; }

        public Invoice(Book book, float price)
        {
            this.Book = book;
            this.Price = price;
        }
    }
}