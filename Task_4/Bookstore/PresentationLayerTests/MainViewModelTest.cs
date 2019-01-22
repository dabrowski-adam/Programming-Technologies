using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Model;
using PresentationLayer.ViewModel;

namespace PresentationLayerTests
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void CreatorTestMethod()
        {
            MainViewModel _vm = new MainViewModel();
            Assert.IsNotNull(_vm.Store);
            Assert.IsNotNull(_vm.Books);
            Assert.IsNull(_vm.CurrentBook);
        }

        [TestMethod]
        public void DataLayerTestMethod()
        {
            MainViewModel _vm = new MainViewModel();
            //Assert.AreEqual(0, _vm.Store.Books.Count());
            Store _dl = new Store();
            _vm.Store = _dl;
            Assert.AreSame(_vm.Store, _dl);
        }

        [TestMethod]
        public void DeleteTestMethod()
        {
            MainViewModel _vm = new MainViewModel();
            
            Store _dl = _vm.Store;
            _vm.Store = _dl;

            Book book = new Book()
            {
                ISBN = "123",
                Title = "Harry",
                Author = "Rowling",
                Price = 4.99f,
            };

            _vm.Books.Add(book);

            _vm.CurrentBook = book;

            Assert.AreEqual(1, _vm.Books.Count());

            _vm.DeleteBook.Execute(null);

            Assert.AreEqual(0, _vm.Books.Count());
        }

        [TestMethod]
        public void ShowConfimationTestMethod()
        {
            MainViewModel _vm = new MainViewModel();
            int _boxShowCount = 0;
            _vm.MessageBoxShowDelegate = (messageBoxText, caption, button, icon) =>
            {
                _boxShowCount++;
                Assert.AreEqual<string>("Are you sure?", messageBoxText);
                Assert.AreEqual<string>("Button interaction", caption);
                Assert.AreEqual<MessageBoxButton>(MessageBoxButton.OK, button);
                Assert.AreEqual<MessageBoxImage>(MessageBoxImage.Information, icon);
                return System.Windows.MessageBoxResult.OK;
            };
            _vm.ShowConfimation.Execute(null);
            Assert.AreEqual<int>(1, _boxShowCount);
        }
    }
}
