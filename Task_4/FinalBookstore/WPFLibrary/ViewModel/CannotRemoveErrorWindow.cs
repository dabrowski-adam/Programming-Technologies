using System.Windows;
using BookstoreLogic.Data;

namespace WPFBookstore
{
    public partial class CannotRemoveErrorWindow : Window
    {
        private void DisplayErrorMessage(Book book)
        {
            string message =
                "You can't remove book '"
                + book.Title +
                "' written by "
                + book.Author +
                " because it's unavailable";

            MessageBlock.Text = message;
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
