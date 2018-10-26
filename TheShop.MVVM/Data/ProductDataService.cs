using System.Collections.Generic;
using TheShop.Model;

namespace TheShop.MVVM.Data
{
	public class ProductDataService : IProductDataService
	{
		public IEnumerable<Product> GetAll()
		{
			return new List<Product>()
			{
				//TODO: load data from real database
				 new Product() {
					 Name ="Dog",
					 Description ="Retriver"
				 },
				 new Product() {
					 Name ="Dog",
					 Description ="Pug"
				 }
			};
		}
	}
}
