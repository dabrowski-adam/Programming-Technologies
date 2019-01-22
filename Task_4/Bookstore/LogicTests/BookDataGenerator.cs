using System;
using System.Collections.Generic;
using Data;

namespace LogicTests
{
    public class BookDataGenerator
    {
        internal static IEnumerable<IBook> PrepareData()
        {
            return new List<IBook>
            {
                new Book(new ISBN("1234567890123")),
                new Book(new ISBN("2234567890123")),
                new Book(new ISBN("3234567890123")),
            };
        }

        private class Book : IBook
        {
            public IISBN ISBN { get; }

            public Book(IISBN isbn)
            {
                ISBN = isbn;
            }

            public bool Equals(IBook other)
            {
                return ISBN.Equals(other.ISBN);
            }

            public override bool Equals(Object obj)
            {
                IBook other = obj as IBook;
                return ISBN.Equals(other.ISBN);
            }

            public override int GetHashCode()
            {
                return ISBN.GetHashCode();
            }
        }

        private class ISBN : IISBN
        {
            public string Id { get; set; }

            public ISBN(string id)
            {
                Id = id;
            }

            public bool Equals(IISBN other)
            {
                return Id.Equals(other.Id);
            }

            public override bool Equals(Object obj)
            {
                ISBN other = obj as ISBN;
                return Id.Equals(other.Id);
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }
    }
}