using System.Windows;

namespace WPFBookstore
{
    public partial class SellResultWindow : Window
    {
        public SellResultWindow(SellResultType type)
        {
            InitializeComponent();
            DisplayMessage(type);
        }
    }


    public enum SellResultType
    {
        SellSuccess,
        CannotSell,
    }
}
