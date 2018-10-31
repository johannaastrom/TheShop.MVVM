using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TheShop.Model;

namespace TheShop.DataAccess
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext() : base("ProductDb")
		{

		}
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
