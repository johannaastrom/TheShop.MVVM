using System.Collections.Generic;
using TheShop.Model;

namespace TheShop.MVVM.Data
{
	public interface IProductDataService
	{
		IEnumerable<Product> GetAll();
	}
}
