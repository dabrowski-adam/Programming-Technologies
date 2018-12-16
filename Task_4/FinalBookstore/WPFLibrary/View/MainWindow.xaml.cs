using System.Windows;
using BookstoreLogic.Services;

namespace WPFBookstore
{
    public partial class MainWindow : Window
    {
        public BookstoreDataService bookstoreService { get; set; }
        BookstoreListSelection currentLLSelection = BookstoreListSelection.None;

        AddBookWindow addBookWindow = null;
        EditBookWindow editBookWindow = null;

        CannotRemoveErrorWindow removalErrorWindow = null;
        BookChangeStatusResultWindow bookChangeStatusResultWindow = null;
        BookSellingWindow bookSellingWindow = null;
        SellResultWindow sellResultWindow = null;


        public MainWindow()
        {
            bookstoreService = new BookstoreDataService();

            InitializeComponent();
            UpdateButtons();
            ShowList();
        }
    }



    public enum BookstoreListSelection
    {
        Books,
        Invoices,
        None,
    }
}
