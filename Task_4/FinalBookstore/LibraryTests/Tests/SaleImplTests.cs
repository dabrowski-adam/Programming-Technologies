using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLogic.LogicImplementations;
using BookstoreLogic.Data;
using System.Collections.Generic;

namespace Bookstore.Tests
{
    [TestClass()]
    public class SaleImplTests
    {
        private BookstoreState bookstoreState;
        private SaleDaoBasicImpl saleDao;

        [TestInitialize()]
        public void SetUp()
        {
            this.bookstoreState = new BookstoreState();
            this.saleDao = new SaleDaoBasicImpl(bookstoreState);
        }

        [TestCleanup()]
        public void TearDown()
        {
            this.saleDao = null;
            this.bookstoreState = null;
        }


        [TestMethod()]
        public void AddSaleTest()
        {
            Book book = new Book("Mój piękny syn", "David Sheff", "Biography",1);
            Sale sale = new Sale(book);
            saleDao.AddSale(sale);

            Assert.AreEqual(saleDao.GetAllInvoices()[0], sale);
        }


        [TestMethod()]
        public void RemoveSaleTest()
        {
            Sale sale1 = new Sale(new Book("h", "i", "j",1));
            Sale sale2 = new Sale(new Book("h", "i", "j",1));

            saleDao.AddSale(sale1);
            saleDao.AddSale(sale2);

            Assert.AreEqual(saleDao.GetAllInvoices().Count, 2);
            saleDao.RemoveSale(1);

            Assert.AreEqual(saleDao.GetAllInvoices().Count, 1);
            Assert.IsTrue(saleDao.GetAllInvoices().Contains(sale1));
        }



        [TestMethod()]
        public void GetSaleTest()
        {
            Sale sale1 = new Sale(new Book("t", "a", "g",1));
            Sale sale2 = new Sale(new Book("t", "a", "g",1));

            saleDao.AddSale(sale1);
            saleDao.AddSale(sale2);

            Sale testSale = saleDao.GetSale(1);
            Assert.AreEqual(sale2, testSale);
        }

    }

}
