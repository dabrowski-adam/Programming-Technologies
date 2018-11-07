namespace Data
{
    public class Invoice
    {
        public ISBN ISBN { get; private set; }
        public float Price { get; private set; }
        public int Number { get; private set; }

        public Invoice(ISBN isbn, float price, int number)
        {
            this.ISBN = isbn;
            this.Price = price;
            this.Number = number;
        }
    }
}