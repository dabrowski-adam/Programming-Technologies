using System;

namespace Data
{
    public class Book
    {
        public String Title { get; private set; }
        public String Author { get; private set; }

        public Book(String title, String author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
