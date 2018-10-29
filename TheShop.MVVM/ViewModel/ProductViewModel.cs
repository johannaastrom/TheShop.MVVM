using Prism.Events;
using System;
using System.Threading.Tasks;
using TheShop.MVVM.Event;

namespace TheShop.MVVM.ViewModel
{
	public class ProductViewModel : ViewModelBase
	{
		private IEventAggregator _eventAggregator;
		private Func<IProductDetailViewModel> _productDetailViewModelCreator;
		private IProductDetailViewModel _productDetailViewModel;

		public ProductViewModel(INavigationViewModel navigationViewModel, Func<IProductDetailViewModel> productViewModelCreator, IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
			NavigationViewModel = navigationViewModel;
			_productDetailViewModelCreator = productViewModelCreator;

			_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
				.Subscribe(OnOpenProductDetailView);

			NavigationViewModel = navigationViewModel;

			//CreateNewProductCommand = new DelegateCommand(OnCreateNewProductExecute);
		}

		public async Task LoadAsync()
		{
			await NavigationViewModel.LoadAsync();
		}

		public INavigationViewModel NavigationViewModel { get; }

		public IProductDetailViewModel ProductDetailViewModel
		{
			get { return _productDetailViewModel; }
			private set
			{
				_productDetailViewModel = value;
				OnPropertyChanged();
			}
		}

		private async void OnOpenProductDetailView(int productId)
		{
			ProductDetailViewModel = _productDetailViewModelCreator();
			await ProductDetailViewModel.LoadAsync(productId);
		}
	}
}
