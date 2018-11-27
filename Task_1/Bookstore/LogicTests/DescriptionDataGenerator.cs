using System.Collections.Generic;
using Data;

namespace LogicTests
{
    public class DescriptionDataGenerator
    {
        internal static IEnumerable<IDescription> PrepareData()
        {
            return new List<IDescription>
            {
                new Description("The Final Empire", "Brandon Sanderson", 29.99f),
                new Description("Ostatnie Życzenie", "Andrzej Sapkowski", 9.99f),
                new Description("Harry Potter and the Philosopher's Stone", "J.K. Rowling", 4.49f),
            };
        }

        private class Description : IDescription
        {
            public string Title { get; }

            public string Author { get; }

            public float Price { get; set; }

            public Description(string title, string author, float price)
            {
                Title = title;
                Author = author;
                Price = price;
            }
        }
    }
}