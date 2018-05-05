using System.Windows;

namespace RedmineControler
{
    /// <summary>
    /// NewTicketDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class NewTicketDialog : Window
    {
        private NewTicketDialogViewModel userModel;

        public NewTicketDialog()
        {
            this.userModel = new NewTicketDialogViewModel( this.Close );
            this.DataContext = this.userModel;
            InitializeComponent();
        }
    }
}
