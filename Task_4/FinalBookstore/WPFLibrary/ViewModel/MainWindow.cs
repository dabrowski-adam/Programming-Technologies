using System;
using System.Windows;
using System.Windows.Controls;
using BookstoreLogic.Data;

namespace WPFBookstore
{
    public partial class MainWindow : Window
    {
        /* Callback Actions */
        #region
        public void Refresh()
        {
            ShowList();
        }

        public void SellReturn(bool success)
        {
            ShowList();

            if (success)
            {
                /* Success */
                if (sellResultWindow == null || !sellResultWindow.IsLoaded)
                {
                    sellResultWindow = new SellResultWindow(SellResultType.SellSuccess);
                    sellResultWindow.Show();
                }
            }
        }
        #endregion


        /* Selecting Bookstore lists */
        #region
        private void BooksButton_Click(object sender, RoutedEventArgs e)
        {
            currentLLSelection = BookstoreListSelection.Books;
            UpdateButtons();
            Refresh();
        }

        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            currentLLSelection = BookstoreListSelection.Invoices;
            UpdateButtons();
            Refresh();
        }
        #endregion


        /* Adding */
        #region
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            /* Decide what to do basing on current Bookstore List selection */
            switch (currentLLSelection)
            {
                case BookstoreListSelection.Books:
                    {
                        if (addBookWindow == null || !addBookWindow.IsLoaded)
                        {
                            addBookWindow = new AddBookWindow(bookstoreService, Refresh);
                            addBookWindow.Show();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion


        /* Editing */
        #region
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                switch (currentLLSelection)
                {
                    case BookstoreListSelection.Books:
                        {
                            Book book = (Book)selection;

                            if (editBookWindow == null || !editBookWindow.IsLoaded)
                            {
                                editBookWindow = new EditBookWindow(bookstoreService, book, Refresh);
                                editBookWindow.Show();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        #endregion


        /* Selling books */
        #region
        private void SellBookButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                Book book = (Book)selection;

                if (book.State != BookState.Available)
                {
                    /* Error */
                    if (sellResultWindow == null || !sellResultWindow.IsLoaded)
                    {
                        sellResultWindow = new SellResultWindow(SellResultType.CannotSell);
                        sellResultWindow.Show();
                    }
                }
                else
                {
                    /* Try to sell the book */
                    if (bookSellingWindow == null || !bookSellingWindow.IsLoaded)
                    {
                        bookSellingWindow = new BookSellingWindow(bookstoreService, book, SellReturn);
                        bookSellingWindow.Show();
                    }
                }
            }
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                Book book = (Book)selection;

                if (book.State == BookState.Available)
                {
                    /* Error */ 
                    if (bookChangeStatusResultWindow == null || !bookChangeStatusResultWindow.IsLoaded)
                    {
                        bookChangeStatusResultWindow = new BookChangeStatusResultWindow(false);
                    }
                }
                else
                {
                    bookstoreService.RemoveSale(book);

                    /* Success */
                    if (bookChangeStatusResultWindow == null || !bookChangeStatusResultWindow.IsLoaded)
                    {
                        bookChangeStatusResultWindow = new BookChangeStatusResultWindow(true);
                        bookChangeStatusResultWindow.Show();
                    }
                }

                Refresh();
            }
        }
        #endregion


        /* Removing */
        #region
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            object selection = DataContextContainer.SelectedItem;

            if (selection != null)
            {
                switch (currentLLSelection)
                {
                    case BookstoreListSelection.Books:
                        {
                            Book book = (Book)selection;

                            try { 
                                bookstoreService.RemoveBook(book);
                                Refresh();
                            }
                            catch
                            {
                                removalErrorWindow = new CannotRemoveErrorWindow(book);
                                removalErrorWindow.Show();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void RemoveAllButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentLLSelection)
            {
                case BookstoreListSelection.Books:
                    {
                        bookstoreService.RemoveAllBooks();
                        Refresh();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion


        /* Showing different lists */
        #region
        private void ShowList()
        {
            DataContextContainer.ItemsSource = null;

            switch (currentLLSelection)
            {
                case BookstoreListSelection.Books:
                    {
                        DataContextTitle.Content = "Books";
                        DataContextContainer.ItemsSource = bookstoreService.GetAllBooks();
                        break;
                    }
                case BookstoreListSelection.Invoices:
                    {
                        DataContextTitle.Content = "Invoices history";
                        DataContextContainer.ItemsSource = bookstoreService.GetAllInvoices();
                        break;
                    }
                default:
                    {
                        DataContextTitle.Content = "";
                        break;
                    }
            }
        }
#endregion


        /* Updating buttons when Bookstore List selection changes */
        #region
        private void UpdateButtons()
        {
            switch (currentLLSelection)
            {
                case BookstoreListSelection.Books:
                    {
                        ControlsText.Text = "Manage Books";
                        AddButton.Content = "Add Book";
                        EditButton.Content = "Edit Book";
                        RemoveButton.Content = "Remove Book";
                        RemoveAllButton.Content = "Remove All Books";

                        AddButton.Visibility = Visibility.Visible;
                        SellBookButton.Visibility = Visibility.Visible;
                        EditButton.Visibility = Visibility.Visible;

                        RemoveButton.Visibility = Visibility.Visible;
                        RemoveAllButton.Visibility = Visibility.Visible;
                        break;
                    }
                case BookstoreListSelection.Invoices:
                    {
                        ControlsText.Text = "No actions to perform select \"Books\" to manage data";
                        AddButton.Content = "";
                        EditButton.Content = "";
                        RemoveButton.Content = "";
                        RemoveAllButton.Content = "";

                        AddButton.Visibility = Visibility.Hidden;
                        SellBookButton.Visibility = Visibility.Hidden;

                        EditButton.Visibility = Visibility.Hidden;

                        RemoveButton.Visibility = Visibility.Hidden;
                        RemoveAllButton.Visibility = Visibility.Hidden;
                        break;
                    }
                case BookstoreListSelection.None:
                default:
                    {
                        ControlsText.Text = "";
                        AddButton.Content = "";
                        EditButton.Content = "";
                        RemoveButton.Content = "";
                        RemoveAllButton.Content = "";

                        AddButton.Visibility = Visibility.Hidden;
                        SellBookButton.Visibility = Visibility.Hidden;
                   
                        EditButton.Visibility = Visibility.Hidden;

                        RemoveButton.Visibility = Visibility.Hidden;
                        RemoveAllButton.Visibility = Visibility.Hidden;
                        break;
                    }
            }
        }
        #endregion


        /* Window events */
        #region
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContextContainer_SelectionChanged(this.DataContextContainer, null);
        }

        private void DataContextContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion
    }
}
