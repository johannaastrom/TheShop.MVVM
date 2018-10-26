using System.Windows;
using TheShop.MVVM.ViewModel;

namespace TheShop.MVVM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ProductViewModel _viewModel;

		public MainWindow(ProductViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			DataContext = viewModel;
			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			_viewModel.Load();
		}
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
