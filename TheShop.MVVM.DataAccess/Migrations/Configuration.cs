namespace TheShop.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;
	using TheShop.Model;

	internal sealed class Configuration : DbMigrationsConfiguration<ProductDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ProductDbContext context)
		{
			context.Products.AddOrUpdate(
				p => p.Name,
				new Product { Name = "Buster", Description = "Pug" },
				new Product { Name = "Kalle", Description = "Pomeranian" },
				new Product { Name = "Pelle", Description = "English Shepherd" },
				new Product { Name = "Bella", Description = "Golden Retriver" }
				);

			context.Categories.AddOrUpdate(
				c => c.Name,
				new Category { Name = "Animal" },
				new Category { Name = "Fruit" },
				new Category { Name = "Tool" },
				new Category { Name = "Plant" }
				);
		}
	}
}
