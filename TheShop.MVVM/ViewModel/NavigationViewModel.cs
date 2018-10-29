using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TheShop.Data.Lookups;
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
			Products = new ObservableCollection<NavigationItemViewModel>();
			_eventAggregator.GetEvent<AfterProductSavedEvent>().Subscribe(AfterProductSaved);
		}

		private void AfterProductSaved(AfterProductSavedEventArgs obj)
		{
			var lookupItem = Products.Single(p => p.Id == obj.Id);
			lookupItem.DisplayProduct = obj.DisplayProduct;
		}

		public async Task LoadAsync()
		{
			var lookup = await _productLookupDataService.GetProductLookupAsync();
			Products.Clear();
			foreach (var item in lookup)
			{
				Products.Add(new NavigationItemViewModel(item.Id, item.DisplayProduct));
			}
		}

		public ObservableCollection<NavigationItemViewModel> Products { get; }

		private NavigationItemViewModel _selectedProduct;

		public NavigationItemViewModel SelectedProduct 
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
