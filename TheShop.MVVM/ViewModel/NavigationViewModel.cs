﻿using Prism.Events;
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
			var lookupItem = Products.SingleOrDefault(p => p.Id == obj.Id);
			if (lookupItem == null)
			{
				Products.Add(new NavigationItemViewModel(obj.Id, obj.DisplayProduct, _eventAggregator));
			}
			else
			{
				lookupItem.DisplayProduct = obj.DisplayProduct;
			}
		}

		public async Task LoadAsync()
		{
			var lookup = await _productLookupDataService.GetProductLookupAsync();
			Products.Clear();
			foreach (var item in lookup)
			{
				Products.Add(new NavigationItemViewModel(item.Id, item.DisplayProduct, _eventAggregator));
			}
		}

		public ObservableCollection<NavigationItemViewModel> Products { get; }
	}
}
