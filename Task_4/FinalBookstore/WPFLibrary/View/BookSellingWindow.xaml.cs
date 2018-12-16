using System;
using System.Windows;
using BookstoreLogic.Data;
using BookstoreLogic.Services;

namespace WPFBookstore
{
    public partial class BookSellingWindow : Window
    {
        BookstoreDataService bookstoreService;
        Action<bool> windowCallback;

        public BookSellingWindow(BookstoreDataService service, Book book, Action<bool> callback)
        {
            bookstoreService = service;
            windowCallback = callback;

            InitializeComponent();
            SetupWindow(book);
        }
    }
}
