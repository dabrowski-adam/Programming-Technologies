using System.Windows;
using BookstoreLogic.Data;

namespace WPFBookstore
{
    public partial class CannotRemoveErrorWindow : Window
    {
        public CannotRemoveErrorWindow(Book book)
        {
            InitializeComponent();
            DisplayErrorMessage(book);
        }
    }
}
