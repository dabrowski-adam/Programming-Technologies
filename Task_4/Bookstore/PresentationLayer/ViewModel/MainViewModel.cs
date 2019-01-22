using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using PresentationLayer.ViewModel.MVVMLight;
using PresentationLayer.Model;
using PresentationLayer.View;
using DataLayer;

namespace PresentationLayer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Store _store;
        private ObservableCollection<Book> _books;
        private Book _currentBook;
        
        private View.UpdateWindow updateWindow = null;

        public MainViewModel()
        {
            Store = new Store();
            ShowConfimation = new RelayCommand(() => { ShowConfirmationWindow(); });
            FetchData = new RelayCommand(() => { Task.Run(() => { /*Store = new Store(); });*/ Store.FetchData(); Books = new ObservableCollection<Book>(Store.Books); }); });
            PersistData = new RelayCommand(() => { Task.Run(() => { Store.PersistData(Books); }); });
            DeleteBook = new RelayCommand(() => { HandleDeleteBook(); });
            AddBook = new RelayCommand(() => { ShowUpdateWindow(false); });
            EditBook = new RelayCommand(() => { ShowUpdateWindow(true); });
        }

        public Store Store
        {
            get => _store;
            set
            {
                _store = value;
                Books = new ObservableCollection<Book>(value.Books);
            }
        }

        #region Action Handlers
        void HandleDeleteBook()
        {
            if (CurrentBook == null) { return; }
            Books.Remove(CurrentBook);
            /*Store.DeleteBook(CurrentBook);*/
        }
        #endregion

        #region Bound Properties
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged();
            }
        }

        public Book CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand FetchData
        {
            get; private set;
        }

        public RelayCommand PersistData
        {
            get; private set;
        }

        public RelayCommand DeleteBook
        {
            get; private set;
        }

        public RelayCommand AddBook
        {
            get; private set;
        }

        public RelayCommand EditBook
        {
            get; private set;
        }

        private void ShowUpdateWindow(bool isEditing)
        {
            if (isEditing && CurrentBook == null) { return; }

            if (!isEditing) { CurrentBook = null; }

            if (updateWindow == null || !updateWindow.IsLoaded)
            {
                updateWindow = new UpdateWindow();
                updateWindow.ShowDialog();
            }
        }

        public RelayCommand ShowConfimation
        {
            get;
            private set;
        }

        public Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = MessageBox.Show;
        
        private void ShowConfirmationWindow()
        {
            MessageBoxShowDelegate("Are you sure?", "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
