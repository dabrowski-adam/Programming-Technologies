using System;

namespace Data
{
    public class Description
    {
        public String Title { get; private set; }
        public String Author { get; private set; }

        public Description(String title, String author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
