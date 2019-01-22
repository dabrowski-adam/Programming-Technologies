using System;
using System.Linq;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesLayer;

namespace ServicesLayerTests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ServiceGetBooks()
        {
            Bookstore service = new Bookstore();
            try
            {
                Assert.IsNotNull(service.GetBooks());
                Assert.AreEqual<int>(0, service.GetBooks().Count());
            }
            finally
            {
                service.RemoveData();
            }
        }

        [TestMethod]
        public void ServiceCreateBook()
        {
            Bookstore service = new Bookstore();
            try
            {
                service.CreateBook("123", "Harry", "Rowling", 4.99f);
                Assert.AreEqual(1, service.GetBooks().Count());
                Book book = service.GetBook(0);
                Assert.AreEqual("123", book.ISBN);
                Assert.AreEqual("Harry", book.Title);
                Assert.AreEqual("Rowling", book.Title);
                Assert.AreEqual(4.99f, book.Price);
            }
            finally
            {
                service.RemoveData();
            }
        }

        [TestMethod]
        public void ServiceUpdateBook()
        {
            Bookstore service = new Bookstore();
            try
            {
                service.CreateBook("123", "Harry", "Rowling", 4.99f);
                service.UpdateBook(0, "321", "Hermione", "King", 2.99f);
                Book book = service.GetBook(0);
                Assert.AreEqual(1, service.GetBooks().Count());
                Assert.AreEqual("321", book.ISBN);
                Assert.AreEqual("Hermione", book.Title);
                Assert.AreEqual("King", book.Title);
                Assert.AreEqual(2.99f, book.Price);
            }
            finally
            {
                service.RemoveData();
            }
        }

        [TestMethod]
        public void ServiceDeleteBook()
        {
            Bookstore service = new Bookstore();
            try
            {
                service.CreateBook("123", "Harry", "Rowling", 4.99f);
                Assert.AreEqual<int>(1, service.GetBooks().Count());
                service.RemoveBook(0);
                Assert.AreEqual<int>(0, service.GetBooks().Count());
            }
            finally
            {
                service.RemoveData();
            }
        }
    }
}
