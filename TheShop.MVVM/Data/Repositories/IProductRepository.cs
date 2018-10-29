using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.MVVM.Data.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int productId);
		Task SaveASync();
	}
}
