using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ServicesLayer;

namespace PresentationLayer.Model
{
    public class Store
    {
        private Bookstore bookstore;
        private List<Book> books;

        public Store()
        {
            bookstore = new Bookstore();
            books = new List<Book>();
            //books = bookstore.GetBooks();
        }

        public IEnumerable<Book> Books
        {
            get => books;
        }

        public void PersistData(IEnumerable<Book> books)
        {
            bookstore.RemoveData();
            foreach (Book book in books)
            {
                bookstore.CreateBook(book.ISBN, book.Title, book.Author, (float)book.Price);
            }
        }

        public void FetchData()
        {
            //bookstore.CreateBook("9780545010221", "Harry Potter and the Deathly Hallows", "Joanne K. Rowling", 4.99f);
            books.Clear();

            var fetchedBooks = bookstore.GetBooks();
            foreach (Book book in fetchedBooks)
            {
                books.Add(book);
            }
        }

        /*public void DeleteBook(Book book)
        {
            //books.Remove(book);
            bookstore.RemoveBook(book.Id);
        }*/
    }
}
