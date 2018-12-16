using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreLogic.Logic;
using BookstoreLogic.Data;

namespace BookstoreLogic.LogicImplementations
{
    public class BookDaoBasicImpl : IBookDao
    {
        private BookstoreState BookstoreData;

        public BookDaoBasicImpl(BookstoreState bookstoreData)
        {
            BookstoreData = bookstoreData;
        }




        public void AddBook(Book book)
        {
            Book existingBook = BookstoreData.BookstoreBooks.Find(b => b.Title.Equals(book.Title) && b.Author.Equals(book.Author));

            if (existingBook != null)
           {
                existingBook.Count += book.Count;
                existingBook.State = BookState.Available;

           } else
           {
                BookstoreData.BookstoreBooks.Add(book);
           }

                
            

        }

        public void UpdateBook(BookUpdateData bookData)
        {
            GetBook(bookData.bookId)?.UpdateBookData(bookData);
        }



        public void RemoveBook(int bookISBN)
        {
            Book book = GetBook(bookISBN);

            if (book != null)
                BookstoreData.BookstoreBooks.Remove(book);
            else
                throw new InvalidOperationException("RemoveBook: Cannot find specified book");
        }




        public Book GetBook(int bookISBN)
        {
            for (int i = 0; i < BookstoreData.BookstoreBooks.Count; i++)
            {
                if (BookstoreData.BookstoreBooks[i].ISBN == bookISBN)
                {
                    return BookstoreData.BookstoreBooks[i];
                }
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            return BookstoreData.BookstoreBooks;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return GetAllBooks().Select(book => book).Where(book => book.Author.Equals(author)).ToList();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            return GetAllBooks().Select(book => book).Where(book => book.Title.Equals(title)).ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            return GetAllBooks().Select(book => book).Where(book => book.Genre.Equals(genre)).ToList();
        }

        public List<Book> GetBooksByState(BookState state)
        {
            return GetAllBooks().Select(book => book).Where(book => book.State.Equals(state)).ToList();
        }




        public void SellBook(int bookISBN)
        {
            GetBook(bookISBN)?.SellBook();
        }

        public void ChangeStatus(int bookISBN)
        {
            GetBook(bookISBN)?.ChangeStatus();
        }
    }
}
