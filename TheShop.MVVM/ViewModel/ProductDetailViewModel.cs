using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TheShop.Model;
using TheShop.MVVM.Data;
using TheShop.MVVM.Event;
using TheShop.MVVM.Wrapper;

namespace TheShop.MVVM.ViewModel
{
	public class ProductDetailViewModel : ViewModelBase, IProductDetailViewModel
	{
		private IProductDataService _productDataService;
		private IEventAggregator _eventAggregator;
		private ProductWrapper _Product;

		public ProductDetailViewModel(IProductDataService productDataService, IEventAggregator eventAggregator)
		{
			_productDataService = productDataService;
			_eventAggregator = eventAggregator;
			_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
				.Subscribe(OnOpenProductDetailView);

			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
		}

		public async Task LoadAsAsync(int productId)
		{
			var product = await _productDataService.GetByIdAsync(productId);

			Product = new ProductWrapper(product);
			Product.PropertyChanged += (s, e) =>
			{
				if (e.PropertyName == nameof(Product.HasErrors))
				{
					((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
				}
			};

			((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
		}

		public ProductWrapper Product
		{
			get { return _Product; }
			private set
			{
				_Product = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveCommand { get; }

		private async void OnSaveExecute()
		{
			await _productDataService.SaveASync(Product.Model);
			_eventAggregator.GetEvent<AfterProductSavedEvent>().Publish(
				new AfterProductSavedEventArgs
				{
					Id = Product.Id,
					DisplayProduct = Product.Name
				});
		}

		private bool OnSaveCanExecute()
		{
			//TODO check in addition if product has changes
			return Product!=null && !Product.HasErrors;
		}

		private async void OnOpenProductDetailView(int productId)
		{
			await LoadAsAsync(productId);
		}
	}
}
