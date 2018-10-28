using Prism.Events;
using System;
using System.Threading.Tasks;
using TheShop.Model;
using TheShop.MVVM.Data;
using TheShop.MVVM.Event;

namespace TheShop.MVVM.ViewModel
{
	public class ProductDetailViewModel : ViewModelBase, IProductDetailViewModel
	{
		private IProductDataService _productDataService;
		private IEventAggregator _eventAggregator;

		public ProductDetailViewModel(IProductDataService productDataService, IEventAggregator eventAggregator)
		{
			_productDataService = productDataService;
			_eventAggregator = eventAggregator;
			_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
				.Subscribe(OnOpenProductDetailView);
		}

		private async void OnOpenProductDetailView(int productId)
		{
			await LoadAsAsync(productId);
		}

		public async Task LoadAsAsync(int productId)
		{
			Product = await _productDataService.GetByIdAsync(productId);
		}

		private Product _Product;
		public Product Product
		{
			get { return _Product; }
			private set
			{
				_Product = value;
				OnPropertyChanged();
			}
		}
	}
}
