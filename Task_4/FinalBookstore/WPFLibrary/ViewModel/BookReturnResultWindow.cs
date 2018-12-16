using System.Windows;

namespace WPFBookstore
{
    public partial class BookChangeStatusResultWindow : Window
    {
        private void DisplayMessage(bool success)
        {
            if (success)
                MessageBlock.Text = "Book status changed successfully.";
            else
                MessageBlock.Text = "Error. This book is currently \n unavailable.";
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
