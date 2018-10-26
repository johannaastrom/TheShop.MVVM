using System.ComponentModel.DataAnnotations;

namespace TheShop.Model
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(50)]
		public string Description { get; set; }
	}
}

