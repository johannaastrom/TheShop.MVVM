using System;
using System.Collections.Generic;
using TheShop.Model;

namespace TheShop.MVVM.Wrapper
{
	public class ProductWrapper : ModelWrapper<Product>
	{
		public ProductWrapper(Product model) : base(model)
		{
		}

		public int Id { get { return Model.Id; } }

		public string Name
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Description
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public int? FavoriteCategoryId
		{
			get { return GetValue<int?>(); }
			set { SetValue(value); }
		}

		protected override IEnumerable<string> ValidateProperty(string propertyName)
		{
			switch (propertyName)
			{
				case nameof(Name):
					if (string.Equals(Name, "Robot", StringComparison.OrdinalIgnoreCase))
					{
						yield return "Robot is not a valis product";
					}
					break;
			}
		}
	}
}
