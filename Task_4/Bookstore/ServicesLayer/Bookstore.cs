using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DataLayer;

namespace ServicesLayer
{
    public class Bookstore
    {
        private BookstoreDataContext bookstore;

        public Bookstore()
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\git\Programming-Technologies\Task_1\Bookstore\DataTests\Instrumentation\Bookstore.mdf;Integrated Security=True;Connect Timeout=30";
            bookstore = new BookstoreDataContext();
        }

        public List<Book> GetBooks()
        {
            return bookstore.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return bookstore.ReadBook(id);
        }

        public void RemoveData()
        {
            bookstore.Stocks.DeleteAllOnSubmit(bookstore.Stocks);
            bookstore.Invoices.DeleteAllOnSubmit(bookstore.Invoices);
            bookstore.Actors.DeleteAllOnSubmit(bookstore.Actors);
            bookstore.Events.DeleteAllOnSubmit(bookstore.Events);
            bookstore.Books.DeleteAllOnSubmit(bookstore.Books);
            bookstore.SubmitChanges();
        }

        // CRUD
        #region Actor
        public void CreateActor(string name)
        {
            Actor _actor = new Actor()
            {
                Name = name,
            };
            bookstore.Actors.InsertOnSubmit(_actor);
            bookstore.SubmitChanges();
        }

        public Actor ReadActor(int id)
        {
            return bookstore.Actors.Where(_actor => _actor.Id == id).FirstOrDefault();
        }

        public void UpdateActor(int id, string name)
        {
            Actor _actor = ReadActor(id);
            if (_actor == null) { throw new InvalidOperationException("Cannot update non-existent Actor."); }
            _actor.Name = name;
            bookstore.SubmitChanges();
        }

        public void RemoveActor(int id)
        {
            Actor _actor = ReadActor(id);
            if (_actor == null) { return; }
            bookstore.Actors.DeleteOnSubmit(_actor);
            bookstore.SubmitChanges();
        }
        #endregion

        #region Book
        public void CreateBook(string isbn, string title, string author, float price)
        {
            Book _book = new Book()
            {
                ISBN = isbn,
                Title = title,
                Author = author,
                Price = price,
            };
            bookstore.Books.InsertOnSubmit(_book);
            bookstore.SubmitChanges();
        }

        public Book ReadBook(int id)
        {
            return bookstore.Books.Where(_book => _book.Id == id).FirstOrDefault();
        }

        public void UpdateBook(int id, string isbn, string title, string author, float price)
        {
            Book _book = ReadBook(id);
            if (_book == null) { throw new InvalidOperationException("Cannot update non-existent Book."); }
            _book.ISBN = isbn;
            _book.Title = title;
            _book.Author = author;
            _book.Price = price;
            bookstore.SubmitChanges();
        }

        public void RemoveBook(int id)
        {
            Book _book = ReadBook(id);
            if (_book == null) { return; }
            bookstore.Books.DeleteOnSubmit(_book);
            bookstore.SubmitChanges();
        }
        #endregion

        #region Event
        public void CreateEvent(Actor actor, Invoice invoice, bool sale)
        {
            Event _event = new Event()
            {
                Actor = actor,
                Invoice = invoice,
                Sale = sale,
            };
            bookstore.Events.InsertOnSubmit(_event);
            bookstore.SubmitChanges();
        }

        public Event ReadEvent(int id)
        {
            return bookstore.Events.Where(_event => _event.Id == id).FirstOrDefault();
        }

        public void UpdateEvent(int id, Actor actor, Invoice invoice, bool sale)
        {
            Event _event = ReadEvent(id);
            if (_event == null) { throw new InvalidOperationException("Cannot update non-existent Event."); }
            _event.Actor = actor;
            _event.Invoice = invoice;
            _event.Sale = sale;
            bookstore.SubmitChanges();
        }

        public void RemoveEvent(int id)
        {
            Event _event = ReadEvent(id);
            if (_event == null) { return; }
            bookstore.Events.DeleteOnSubmit(_event);
            bookstore.SubmitChanges();
        }
        #endregion

        #region Invoice
        public void CreateInvoice(Book book, float price, int number)
        {
            Invoice _invoice = new Invoice()
            {
                Book = book,
                Price = price,
                Number = number,
            };
            bookstore.Invoices.InsertOnSubmit(_invoice);
            bookstore.SubmitChanges();
        }

        public Invoice ReadInvoice(int id)
        {
            return bookstore.Invoices.Where(_invoice => _invoice.Id == id).FirstOrDefault();
        }

        public void UpdateInvoice(int id, Book book, float price, int number)
        {
            Invoice _invoice = ReadInvoice(id);
            if (_invoice == null) { throw new InvalidOperationException("Cannot update non-existent Invoice."); }
            _invoice.Book = book;
            _invoice.Price = price;
            _invoice.Number = number;
            bookstore.SubmitChanges();
        }

        public void RemoveInvoice(int id)
        {
            Invoice _invoice = ReadInvoice(id);
            if (_invoice == null) { return; }
            bookstore.Invoices.DeleteOnSubmit(_invoice);
            bookstore.SubmitChanges();
        }
        #endregion

        #region Stock
        public void CreateStock(Book book, int number)
        {
            Stock _stock = new Stock()
            {
                Book = book,
                Number = number,
            };
            bookstore.Stocks.InsertOnSubmit(_stock);
            bookstore.SubmitChanges();
        }

        public Stock ReadStock(int id)
        {
            return bookstore.Stocks.Where(_stock => _stock.Id == id).FirstOrDefault();
        }

        public void UpdateStock(int id, Book book, int number)
        {
            Stock _stock = ReadStock(id);
            if (_stock == null) { throw new InvalidOperationException("Cannot update non-existent Stock."); }
            _stock.Book = book;
            _stock.Number = number;
            bookstore.SubmitChanges();
        }

        public void RemoveStock(int id)
        {
            Stock _stock = ReadStock(id);
            if (_stock == null) { return; }
            bookstore.Stocks.DeleteOnSubmit(_stock);
            bookstore.SubmitChanges();
        }
        #endregion
    }
}
