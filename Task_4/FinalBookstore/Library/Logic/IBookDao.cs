using System.Collections.Generic;
using BookstoreLogic.Data;

namespace BookstoreLogic.Logic
{
    public interface IBookDao
    {
        void AddBook(Book book);
        void UpdateBook(BookUpdateData bookData);

        void RemoveBook(int bookISBN);

        Book GetBook(int bookISBN);
        List<Book> GetAllBooks();
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksByTitle(string title);
        List<Book> GetBooksByGenre(string genre);
        List<Book> GetBooksByState(BookState state);
       
        void SellBook(int bookISBN);
        void ChangeStatus(int bookISBN);
    }
}
