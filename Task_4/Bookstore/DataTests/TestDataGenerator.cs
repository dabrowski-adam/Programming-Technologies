using System;
using System.Collections.Generic;
using DataLayer;

namespace DataTests
{
    public class TestDataGenerator
    {
        internal static IEnumerable<Book> PrepareData()
        {
            return new List<Book>()
            {
                new Book()
                {
                    ISBN = "1234",
                    Title = "Harry Potter",
                    Author = "J. K. Rowling",
                    Price = 4.99f,
                },
                new Book()
                {
                    ISBN = "1234",
                    Title = "Hermione Granger",
                    Author = "J. K. Rowling",
                    Price = 2.99f,
                },
        };
        }
    }
}