using System;
using System.Windows;
using BookstoreLogic.Services;

namespace WPFBookstore
{
    public partial class AddBookWindow : Window
    {
        ModificationResultWindow addResultWindow = null;

        BookstoreDataService bookstoreService;
        Action windowCallback;

        public AddBookWindow(BookstoreDataService service, Action callback)
        {
            bookstoreService = service;
            windowCallback = callback;

            InitializeComponent();
            SetupWindow();
        }
    }
}
