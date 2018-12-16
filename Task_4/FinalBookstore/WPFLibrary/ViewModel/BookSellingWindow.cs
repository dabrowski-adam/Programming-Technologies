using System.Windows;
using System.Windows.Controls;
using BookstoreLogic.Data;

namespace WPFBookstore
{
    public partial class BookSellingWindow : Window
    {
        private int soldBookId;

        private void SetupWindow(Book book)
        {
            soldBookId = book.ISBN;
        }


        /* Buttons */
        #region
        private void SellBookButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                bookstoreService.AddSale(soldBookId);
                windowCallback(true);
                this.Close();
            }
            catch
            {
                windowCallback(false);
                this.Close();
            } 
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
