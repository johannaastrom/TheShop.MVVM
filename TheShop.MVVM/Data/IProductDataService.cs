using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.MVVM.Data
{
	public interface IProductDataService
	{
		Task<Product> GetByIdAsync(int productId);
		Task SaveASync(Product product);
	}
}
