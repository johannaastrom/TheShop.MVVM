using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TheShop.Data.Lookups;
using TheShop.Model;
using TheShop.MVVM.Data.Repositories;
using TheShop.MVVM.Event;
using TheShop.MVVM.View.Services;
using TheShop.MVVM.Wrapper;

namespace TheShop.MVVM.ViewModel
{
	public class ProductDetailViewModel : ViewModelBase, IProductDetailViewModel
	{
		private IProductRepository _productRepository;
		private IEventAggregator _eventAggregator;
		private IMessageDialogService _messageDialogService;
		private ICategoryLookupDataService _categoryLookupDataService;
		private ProductWrapper _Product;
		private bool _hasChanges;

		public ProductDetailViewModel(IProductRepository productRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService, ICategoryLookupDataService categoryLookupDataService)
		{
			_productRepository = productRepository;
			_eventAggregator = eventAggregator;
			_messageDialogService = messageDialogService;
			_categoryLookupDataService = categoryLookupDataService;

			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
			DeleteCommand = new DelegateCommand(OnDeleteExecute);

			Categories = new ObservableCollection<LookupItem>();
		}

		public async Task LoadAsync(int? productId)
		{
			var product = productId.HasValue ? await _productRepository.GetByIdAsync(productId.Value) : CreateNewProduct();

			InitializeProduct(product);

			await LoadCategoriesLookupAsync();
		}

		private void InitializeProduct(Product product)
		{
			Product = new ProductWrapper(product);
			Product.PropertyChanged += (s, e) =>
			{
				if (!HasChanges)
				{
					HasChanges = _productRepository.HasChanges();
				}
				if (e.PropertyName == nameof(Product.HasErrors))
				{
					((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
				}
			};

			((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
			if (Product.Id == 0)
			{
				Product.Name = "";
			}
		}

		private async Task LoadCategoriesLookupAsync()
		{
			Categories.Clear();
			var lookup = await _categoryLookupDataService.GetCategoryLookupAsync();
			foreach (var lookupItem in lookup)
			{
				Categories.Add(lookupItem);
			}
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

		public bool HasChanges
		{
			get { return _hasChanges; }
			set
			{
				if (_hasChanges != value)
				{
					_hasChanges = value;
					OnPropertyChanged();
					((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
				}
			}
		}

		public ICommand SaveCommand { get; }

		public ICommand DeleteCommand { get; }

		public ObservableCollection<LookupItem> Categories { get; }

		private async void OnSaveExecute()
		{
			await _productRepository.SaveASync();
			HasChanges = _productRepository.HasChanges();
			_eventAggregator.GetEvent<AfterProductSavedEvent>().Publish(
				new AfterProductSavedEventArgs
				{
					Id = Product.Id,
					DisplayProduct = Product.Name
				});
		}

		private bool OnSaveCanExecute()
		{
			return Product != null && !Product.HasErrors && HasChanges;
		}

		private Product CreateNewProduct()
		{
			var product = new Product();
			_productRepository.Add(product);
			return product;
		}

		private async void OnDeleteExecute()
		{
			var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the product {Product.Name}?", "Question");
			if (result == MessageDialogResult.OK)
			{
				_productRepository.Remove(Product.Model);
				await _productRepository.SaveASync();
				_eventAggregator.GetEvent<AfterProductDeletedEvent>().Publish(Product.Id);
			}
		}
	}
}
