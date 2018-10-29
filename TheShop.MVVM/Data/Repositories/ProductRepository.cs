using System.Data.Entity;
using System.Threading.Tasks;
using TheShop.DataAccess;
using TheShop.Model;

namespace TheShop.MVVM.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private ProductDbContext _context;

		public ProductRepository(ProductDbContext context)
		{
			_context = context;
		}

		public void Add(Product product)
		{
			_context.Products.Add(product);
		}
		public void Remove(Product product)
		{
			_context.Products.Remove(product);
		}

		public async Task<Product> GetByIdAsync(int productId)
		{
			//Load data from database
			return await _context.Products.SingleAsync(p => p.Id == productId);
		}

		public bool HasChanges()
		{
			return _context.ChangeTracker.HasChanges();
		}

		public async Task SaveASync()
		{
			await _context.SaveChangesAsync();
		}
	}
}