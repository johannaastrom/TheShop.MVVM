using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheShop.Data;
using TheShop.Model;

namespace TheShop.MVVM.ViewModel
{
	public class NavigationViewModel : INavigationViewModel
	{
		private IProductLookupDataService _productLookupDataService;

		public NavigationViewModel(IProductLookupDataService productLookupDataService)
		{
			_productLookupDataService = productLookupDataService;
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
	}
}
