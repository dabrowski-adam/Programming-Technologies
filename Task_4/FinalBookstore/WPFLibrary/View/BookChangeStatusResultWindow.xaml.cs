using System.Windows;

namespace WPFBookstore
{
    public partial class BookChangeStatusResultWindow : Window
    {
        public BookChangeStatusResultWindow(bool success)
        {
            InitializeComponent();
            DisplayMessage(success);
        }
    }
}
