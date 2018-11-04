namespace Data
{
    public class Book
    {
        public Description Description { get; private set; }
        public float Price { get; private set; }

        public Book(Description description, float price)
        {
            this.Description = description;
            this.Price = price;
        }
    }
}
