using MahApps.Metro.Controls;
using System.Windows;
using TheShop.MVVM.ViewModel;

namespace TheShop.MVVM
{
	public partial class MainWindow : MetroWindow
	{
		private ProductViewModel _viewModel;

		public MainWindow(ProductViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			DataContext = viewModel;
			Loaded += MainWindow_Loaded;
		}

		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await _viewModel.LoadAsync();
		}
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
