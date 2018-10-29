using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TheShop.DataAccess;
using TheShop.Model;

namespace TheShop.Data.Lookups
{
	public class LookupDataService : IProductLookupDataService, ICategoryLookupDataService
	{
		private Func<ProductDbContext> _contextCreator;

		public LookupDataService(Func<ProductDbContext> contextCreator)
		{
			_contextCreator = contextCreator;
		}

		public async Task<IEnumerable<LookupItem>> GetProductLookupAsync()
		{
			using(var ctx = _contextCreator())
			{
				return await ctx.Products.AsNoTracking()
					.Select(p =>
					new LookupItem
					{
						Id = p.Id,
						DisplayProduct = p.Name
					})
					.ToListAsync();
			}
		}

		public async Task<IEnumerable<LookupItem>> GetCategoryLookupAsync()
		{
			using (var ctx = _contextCreator())
			{
				return await ctx.Categories.AsNoTracking()
					.Select(c =>
					new LookupItem
					{
						Id = c.Id,
						DisplayProduct = c.Name
					})
					.ToListAsync();
			}
		}
	}
}
