namespace TheShop.MVVM.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;
	using TheShop.Model;

	internal sealed class Configuration : DbMigrationsConfiguration<TheShop.DataAccess.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheShop.DataAccess.ProductDbContext context)
        {
			context.Products.AddOrUpdate(
				p => p.Name,
				new Product { Name = "Buster", Description="Pug" },
				new Product { Name = "Kalle", Description = "Pomeranian" },
				new Product { Name = "Pelle", Description = "English Shepherd" },
				new Product { Name = "Bella", Description = "Golden Retriver" }
				);
        }
    }
}
