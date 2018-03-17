using System.Windows;

namespace RedmineControler
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainWindowViewModel userModel = new MainWindowViewModel();
		public MainWindow()
		{
			this.DataContext = this.userModel;
			InitializeComponent();
		}
    }
}
