using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;

namespace DataTests
{
    [TestClass]
    //[DeploymentItem(@"C:\git\Programming-Technologies\Task_1\Bookstore\DataTests\Instrumentation\Bookstore.mdf", @"Instrumentation")]
    public class LinqUnitTest
    {
        [TestMethod]
        public void DataContextTest()
        {
            using (BookstoreDataContext _newCatalog = new BookstoreDataContext())
            {
                Assert.IsNotNull(_newCatalog.Connection);
                Assert.AreEqual<int>(0, _newCatalog.Actors.Count());
                Assert.AreEqual<int>(0, _newCatalog.Books.Count());
                Assert.AreEqual<int>(0, _newCatalog.Events.Count());
                Assert.AreEqual<int>(0, _newCatalog.Invoices.Count());
                Assert.AreEqual<int>(0, _newCatalog.Stocks.Count());

                try
                {
                    _newCatalog.Books.InsertAllOnSubmit(TestDataGenerator.PrepareData());
                    _newCatalog.SubmitChanges();
                    Assert.AreEqual<int>(2, _newCatalog.Books.Count());
                }
                finally
                {
                    _newCatalog.Books.DeleteAllOnSubmit(_newCatalog.Books);
                    _newCatalog.SubmitChanges();
                }
            }
        }
    }
}
