using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Logic
{
    public class CatalogLogic
    {
        Catalog catalog = new Catalog();

        public void Add(String title, String author, ISBN isbn, float price)
        {
            Book book = new Book(new Description(title, author), price);
            
            if (!catalog.ContainsValue(book))
            {
                try
                {
                    catalog.Add(isbn, book);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("ISBN is probably already taken");
                    return;

                }

            }
            else Console.WriteLine("Catalog already contains the book: {0}, {1}" + title + author);



        }

        public void Remove(Catalog catalog, ISBN isbn)
        {
        
            try
            {
                Console.WriteLine("Removing a book{0}, {1}" + catalog[isbn].Description.Title + catalog[isbn].Description.Author);


            }

            catch (KeyNotFoundException n)
            {
                Console.WriteLine("Catalog doesn't contain a book with ISBN {0}" + isbn);
                return;
            }
        }
    }
    
}
