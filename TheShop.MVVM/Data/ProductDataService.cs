using System;
using System.Data.Entity;
using System.Threading.Tasks;
using TheShop.DataAccess;
using TheShop.Model;

namespace TheShop.MVVM.Data
{
	public class ProductDataService : IProductDataService
	{
		private Func<ProductDbContext> _contextCreator;

		public ProductDataService(Func<ProductDbContext> contextCreator)
		{
			_contextCreator = contextCreator;
		}

		public async Task<Product> GetByIdAsync(int productId)
		{
			//Load data from database
			using (var ctx = _contextCreator())
			{
				return await ctx.Products.AsNoTracking().SingleAsync(p => p.Id == productId);
			}
		}
	}
}