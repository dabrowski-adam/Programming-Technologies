using System.Collections.Generic;
using BookstoreLogic.Data;
using BookstoreLogic.Logic;
using BookstoreLogic.LogicImplementations;

namespace BookstoreLogic.Services
{
    public class BookstoreDataService
    {
        private BookstoreUOW bookstoreUOW;

        public BookstoreDataService()
        {
            BookstoreState BookstoreState = new BookstoreState();
            BookDaoBasicImpl bookDao = new BookDaoBasicImpl(BookstoreState);
            SaleDaoBasicImpl saleDao = new SaleDaoBasicImpl(BookstoreState);

            bookstoreUOW = new BookstoreUOW(BookstoreState, bookDao, saleDao);
            FillBookstoreDataWithConstants();
        }


        // Removing data
        #region 
        public void RemoveAllData()
        {
            bookstoreUOW.RemoveAllData();
        }
        public void RemoveAllBooks()
        {
            bookstoreUOW.RemoveAllBooks();
        } 
        public void RemoveAllInvoices()
        {
            bookstoreUOW.RemoveAllInvoices();
        }
        #endregion


        // Filling the Bookstore data
        #region
        public void FillBookstoreDataWithConstants()
        {
            ConstantsBookstoreFiller Filler = new ConstantsBookstoreFiller();
            bookstoreUOW.FillBookstoreState(Filler);
        }
        #endregion


        // Books Service
        #region
        public void AddBook(Book book)
        {
            bookstoreUOW.GetBooksDao.AddBook(book);
        }
        public void AddBook(string title, string author, string genre, int count)
        {
            bookstoreUOW.GetBooksDao.AddBook(new Book(title, author, genre, count));
        }

        public void UpdateBook(BookUpdateData data)
        {
            bookstoreUOW.GetBooksDao.UpdateBook(data);
        }
        public void UpdateBook(int id, string title, string author, string genre)
        {
            bookstoreUOW.GetBooksDao.UpdateBook(new BookUpdateData(id, title, author, genre));
        }

        public void RemoveBook(int id)
        {
            bookstoreUOW.GetBooksDao.RemoveBook(id);
        }
        public void RemoveBook(Book book)
        {
            RemoveBook(book.ISBN);
        }
      
        public Book GetBook(int id)
        {
            return bookstoreUOW.GetBooksDao.GetBook(id);
        }
        public List<Book> GetAllBooks()
        {
            return bookstoreUOW.GetBooksDao.GetAllBooks();
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            return bookstoreUOW.GetBooksDao.GetBooksByAuthor(author);
        }
        public List<Book> GetBooksByTitle(string title)
        {
            return bookstoreUOW.GetBooksDao.GetBooksByTitle(title);
        }
        public List<Book> GetBooksByGenre(string genre)
        {
            return bookstoreUOW.GetBooksDao.GetBooksByGenre(genre);
        }
        public List<Book> GetBooksByState(BookState state)
        {
            return bookstoreUOW.GetBooksDao.GetBooksByState(state);
        }

        public void SellBook(int id)
        {
            bookstoreUOW.GetBooksDao.SellBook(id);
        }
        public void ChangeStatus(int id)
        {
            bookstoreUOW.GetBooksDao.ChangeStatus(id);
        }
        #endregion


        // Invoices Service
        #region
        public void AddSale(int bookId)
        {
            Book book = bookstoreUOW.GetBooksDao.GetBook(bookId);

            bookstoreUOW.GetInvoicesDao.AddSale(new Sale(book));
        }
        public void AddSale(Sale sale)
        {
            bookstoreUOW.GetInvoicesDao.AddSale(sale);
        }
        
        public void RemoveSale(int id)
        {
            bookstoreUOW.GetInvoicesDao.RemoveSale(id);
        }
        public void RemoveSale(Sale sale)
        {
            RemoveSale(sale.ID);
        }
        public void RemoveSale(Book soldBook)
        {
            bookstoreUOW.GetInvoicesDao.RemoveSale(soldBook);
        }

        public Sale GetSale(int id)
        {
            return bookstoreUOW.GetInvoicesDao.GetSale(id);
        }
        public List<Sale> GetAllInvoices()
        {
            return bookstoreUOW.GetInvoicesDao.GetAllInvoices();
        }
        #endregion


        // Counting objects
        #region
        public int BooksCount()
        {
            return bookstoreUOW.GetBooksDao.GetAllBooks().Count;
        }

        public int InvoicesCount()
        {
            return bookstoreUOW.GetInvoicesDao.GetAllInvoices().Count;
        }
        #endregion
    }
}
