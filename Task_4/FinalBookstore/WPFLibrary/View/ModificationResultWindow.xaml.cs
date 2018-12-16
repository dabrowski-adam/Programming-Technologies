using System.Windows;


namespace WPFBookstore
{
    public partial class ModificationResultWindow : Window
    {
        public ModificationResultWindow(ModificationResultType resultType)
        {
            InitializeComponent();
            DisplayMessage(resultType);
        }
    }


    public enum ModificationResultType
    {
        BookAddition,
        BookAdditionFail,
        BookEditCorrect,
        BookEditError,
    }
}
