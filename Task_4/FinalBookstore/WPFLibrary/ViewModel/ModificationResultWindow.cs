using System.Windows;

namespace WPFBookstore
{
    public partial class ModificationResultWindow : Window
    {
        private void DisplayMessage(ModificationResultType result)
        { 
            switch (result)
            {
                case ModificationResultType.BookEditCorrect:
                    {
                        MessageBlock.Text = "Book updated successfully.";
                        break;
                    }
                case ModificationResultType.BookAddition:
                    {
                        MessageBlock.Text = "Book added successfully.";
                        break;
                    }

                case ModificationResultType.BookEditError:
                case ModificationResultType.BookAdditionFail:  
                    {
                        MessageBlock.Text = "Error. There are some text fields which are empty. Make sure that everything is filled correctly.";
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
