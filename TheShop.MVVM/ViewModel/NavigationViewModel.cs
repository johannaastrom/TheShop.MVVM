using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheShop.Data;
using TheShop.Model;
using TheShop.MVVM.Event;

namespace TheShop.MVVM.ViewModel
{
	public class NavigationViewModel : ViewModelBase, INavigationViewModel
	{
		private IProductLookupDataService _productLookupDataService;
		private IEventAggregator _eventAggregator;

		public NavigationViewModel(IProductLookupDataService productLookupDataService, IEventAggregator eventAggregator)
		{
			_productLookupDataService = productLookupDataService;
			_eventAggregator = eventAggregator;
			Products = new ObservableCollection<LookupItem>();
		}

		public async Task LoadAsync()
		{
			var lookup = await _productLookupDataService.GetProductLookupAsync();
			Products.Clear();
			foreach (var item in lookup)
			{
				Products.Add(item);
			}
		}

		public ObservableCollection<LookupItem> Products { get; }

		private LookupItem _selectedProduct;

		public LookupItem SelectedProduct 
		{
			get { return _selectedProduct; }
			set
			{
				_selectedProduct = value;
				OnPropertyChanged();
				if (_selectedProduct!=null)
				{
					_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
						.Publish(_selectedProduct.Id);
				}
			}
		}

	}
}
