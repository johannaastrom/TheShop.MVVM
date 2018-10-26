using TheShop.MVVM.Data;
using TheShop.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace TheShop.MVVM.ViewModel
{
	public class ProductViewModel : ViewModelBase
	{
		public ProductViewModel(INavigationViewModel navigationViewModel, IProductDetailViewModel productViewModel)
		{
			NavigationViewModel = navigationViewModel;
			ProductDetailViewModel = productViewModel;

			//CreateNewProductCommand = new DelegateCommand(OnCreateNewProductExecute);
		}

		public async Task LoadAsync()
		{
			await NavigationViewModel.LoadAsync();
		}

		public INavigationViewModel NavigationViewModel { get; }
		public IProductDetailViewModel ProductDetailViewModel { get; }
	}
}
