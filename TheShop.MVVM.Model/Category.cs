using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TheShop.Model
{
	public class Category
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
