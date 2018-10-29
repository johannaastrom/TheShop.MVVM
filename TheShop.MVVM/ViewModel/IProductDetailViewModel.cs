using System.Threading.Tasks;

namespace TheShop.MVVM.ViewModel
{
	public interface IProductDetailViewModel
	{
		Task LoadAsync(int? productId);
		bool HasChanges { get; }
	}
}