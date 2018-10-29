using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Model
{
	public class Category
	{
		public Category()
		{
			Products = new Collection<Product>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public ICollection<Product> Products { get; set; }
	}
}
