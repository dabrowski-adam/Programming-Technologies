using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataLayer
{
    public partial class BookstoreDataContext
    {
        #region Actor
        public void CreateActor(string name)
        {
            Actor _actor = new Actor()
            {
                Name = name,
            };
            Actors.InsertOnSubmit(_actor);
            SubmitChanges();
        }

        public Actor ReadActor(int id)
        {
            return Actors.Where(_actor => _actor.Id == id).FirstOrDefault();
        }

        public void UpdateActor(int id, string name)
        {
            Actor _actor = ReadActor(id);
            if (_actor == null) { throw new InvalidOperationException("Cannot update non-existent Actor."); }
            _actor.Name = name;
            SubmitChanges();
        }

        public void RemoveActor(int id)
        {
            Actor _actor = ReadActor(id);
            if (_actor == null) { return; }
            Actors.DeleteOnSubmit(_actor);
            SubmitChanges();
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
            Books.InsertOnSubmit(_book);
            SubmitChanges();
        }

        public Book ReadBook(int id)
        {
            return Books.Where(_book => _book.Id == id).FirstOrDefault();
        }

        public void UpdateBook(int id, string isbn, string title, string author, float price)
        {
            Book _book = ReadBook(id);
            if (_book == null) { throw new InvalidOperationException("Cannot update non-existent Book."); }
            _book.ISBN = isbn;
            _book.Title = title;
            _book.Author = author;
            _book.Price = price;
            SubmitChanges();
        }

        public void RemoveBook(int id)
        {
            Book _book = ReadBook(id);
            if (_book == null) { return; }
            Books.DeleteOnSubmit(_book);
            SubmitChanges();
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
            Events.InsertOnSubmit(_event);
            SubmitChanges();
        }

        public Event ReadEvent(int id)
        {
            return Events.Where(_event => _event.Id == id).FirstOrDefault();
        }

        public void UpdateEvent(int id, Actor actor, Invoice invoice, bool sale)
        {
            Event _event = ReadEvent(id);
            if (_event == null) { throw new InvalidOperationException("Cannot update non-existent Event."); }
            _event.Actor = actor;
            _event.Invoice = invoice;
            _event.Sale = sale;
            SubmitChanges();
        }

        public void RemoveEvent(int id)
        {
            Event _event = ReadEvent(id);
            if (_event == null) { return; }
            Events.DeleteOnSubmit(_event);
            SubmitChanges();
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
            Invoices.InsertOnSubmit(_invoice);
            SubmitChanges();
        }

        public Invoice ReadInvoice(int id)
        {
            return Invoices.Where(_invoice => _invoice.Id == id).FirstOrDefault();
        }

        public void UpdateInvoice(int id, Book book, float price, int number)
        {
            Invoice _invoice = ReadInvoice(id);
            if (_invoice == null) { throw new InvalidOperationException("Cannot update non-existent Invoice."); }
            _invoice.Book = book;
            _invoice.Price = price;
            _invoice.Number = number;
            SubmitChanges();
        }

        public void RemoveInvoice(int id)
        {
            Invoice _invoice = ReadInvoice(id);
            if (_invoice == null) { return; }
            Invoices.DeleteOnSubmit(_invoice);
            SubmitChanges();
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
            Stocks.InsertOnSubmit(_stock);
            SubmitChanges();
        }

        public Stock ReadStock(int id)
        {
            return Stocks.Where(_stock => _stock.Id == id).FirstOrDefault();
        }

        public void UpdateStock(int id, Book book, int number)
        {
            Stock _stock = ReadStock(id);
            if (_stock == null) { throw new InvalidOperationException("Cannot update non-existent Stock."); }
            _stock.Book = book;
            _stock.Number = number;
            SubmitChanges();
        }

        public void RemoveStock(int id)
        {
            Stock _stock = ReadStock(id);
            if (_stock == null) { return; }
            Stocks.DeleteOnSubmit(_stock);
            SubmitChanges();
        }
        #endregion
    }
}
