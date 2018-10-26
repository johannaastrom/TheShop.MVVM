using System.Threading.Tasks;

namespace TheShop.MVVM.ViewModel
{
	public interface IProductDetailViewModel
	{
		Task LoadAsAsync(int productId);
	}
}