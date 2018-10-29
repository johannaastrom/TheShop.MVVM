using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;
using TheShop.MVVM.Data.Repositories;
using TheShop.MVVM.Event;
using TheShop.MVVM.Wrapper;

namespace TheShop.MVVM.ViewModel
{
	public class ProductDetailViewModel : ViewModelBase, IProductDetailViewModel
	{
		private IProductRepository _productRepository;
		private IEventAggregator _eventAggregator;
		private ProductWrapper _Product;

		public ProductDetailViewModel(IProductRepository productRepository, IEventAggregator eventAggregator)
		{
			_productRepository = productRepository;
			_eventAggregator = eventAggregator;

			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
		}

		public async Task LoadAsync(int productId)
		{
			var product = await _productRepository.GetByIdAsync(productId);

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
			await _productRepository.SaveASync();
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
	}
}
