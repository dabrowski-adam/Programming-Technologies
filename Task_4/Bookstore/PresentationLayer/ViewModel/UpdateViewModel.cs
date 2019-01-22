using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using PresentationLayer.ViewModel.MVVMLight;
using PresentationLayer.Model;
using DataLayer;
using System.ComponentModel;

namespace PresentationLayer.ViewModel
{
    public class UpdateViewModel : ViewModelBase, IDataErrorInfo
    {
        private Book book;

        private string _title;
        private string _author;
        private string _isbn;
        private string _price;
        private bool _isEditing;

        public UpdateViewModel()
        {
            book = ViewModelLocator.Main.CurrentBook;
            if (book != null)
            {
                Title = book.Title;
                Author = book.Author;
                ISBN = book.ISBN;
                Price = book.Price.ToString();
            }

            UpdateBook = new RelayCommand(() => { HandleUpdateBook(); });
        }

        #region Action Handlers
        void HandleUpdateBook()
        {
            if (book != null)
            {
                book.Title = Title;
                book.Author = Author;
                book.ISBN = ISBN;
                book.Price = float.Parse(Price);
            }
            else
            {
                ViewModelLocator.Main.Books.Add(new Book() {
                    Title = Title ?? "",
                    Author = Author ?? "",
                    ISBN = ISBN ?? "",
                    Price = Price != null ? float.Parse(Price) : 0,
                });
            }
        }
        #endregion

        #region Bound Properties
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                RaisePropertyChanged();
            }
        }
        public string ISBN
        {
            get => _isbn;
            set
            {
                _isbn = value;
                RaisePropertyChanged();
            }
        }
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }

        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand UpdateBook
        {
            get; private set;
        }
        #endregion

        #region Validation
        public string Error => throw new NotImplementedException();

        public string this[string propertyName] {
            get
            {
                if (propertyName == "Author")
                {
                    if (Author == null)
                    {
                        return "Please enter the Author.";
                    } else if (Author.Trim() == string.Empty)
                    {
                        return "Author is required.";
                    }
                }
                else if (propertyName == "Title")
                {
                    if (Title == null)
                    {
                        return "Please enter the Title.";
                    }
                    else if (Title.Trim() == string.Empty)
                    {
                        return "Title is required.";
                    }
                }
                else if (propertyName == "ISBN")
                {
                    if (ISBN == null)
                    {
                        return "Please enter the ISBN.";
                    }
                    else if (ISBN.Trim() == string.Empty)
                    {
                        return "ISBN is required.";
                    }
                }
                else if (propertyName == "Price")
                {
                    float price;
                    if (!float.TryParse(Price, out price))
                    {
                        return "Price must be a number.";
                    }
                }
                return null;
            }
        }
        #endregion
    }
}
