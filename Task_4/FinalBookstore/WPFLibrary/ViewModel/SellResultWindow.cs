using System.Windows;

namespace WPFBookstore
{
    public partial class SellResultWindow : Window
    {
        private void DisplayMessage(SellResultType type)
        {
            switch (type)
            {
                case SellResultType.SellSuccess:
                    {
                        MessageBlock.Text = "Book sold successfully.";
                        break;
                    }
                case SellResultType.CannotSell:
                    {
                        MessageBlock.Text = "Error. This book is sold.";
                        break;
                    }
                default:
                    {
                        MessageBlock.Text = "Error.";
                        break;
                    }
            }
        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
