using System.Windows;
using BookstoreLogic.Data;

namespace WPFBookstore
{
    public partial class EditBookWindow : Window
    {
        private int editedBookId;

        private void SetupWindow(Book book)
        {
            editedBookId = book.ISBN;

            TitleText.Text = book.Title;
            AuthorText.Text = book.Author;
            GenreText.Text = book.Genre;
        }

        private void UpdateBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckIfEmpty(TitleText.Text) && !CheckIfEmpty(AuthorText.Text) && !CheckIfEmpty(GenreText.Text))
            {
                bookstoreService.UpdateBook(editedBookId, TitleText.Text, AuthorText.Text, GenreText.Text);
                windowCallback();

                //Display success message
                if (editResultWindow == null || !editResultWindow.IsLoaded)
                {
                    editResultWindow = new ModificationResultWindow(ModificationResultType.BookEditCorrect);
                    editResultWindow.Show();
                }
            }
            else
            {
                //Display error message
                if (editResultWindow == null || !editResultWindow.IsLoaded)
                {
                    editResultWindow = new ModificationResultWindow(ModificationResultType.BookEditError);
                    editResultWindow.Show();
                }
            }
        }

        private bool CheckIfEmpty(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() != " ")
                    return false;
            }
            return true;
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (editResultWindow != null && editResultWindow.IsLoaded)
                editResultWindow.Close();
            this.Close();
        }
    }
}