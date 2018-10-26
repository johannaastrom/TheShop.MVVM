using System.Threading.Tasks;
using TheShop.Model;
using TheShop.MVVM.Data;

namespace TheShop.MVVM.ViewModel
{
	public class ProductDetailViewModel : ViewModelBase, IProductDetailViewModel
	{
		private IProductDataService _productDataService;

		public ProductDetailViewModel(IProductDataService productDataService)
		{
			_productDataService = productDataService;
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
