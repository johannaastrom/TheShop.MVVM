﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Data.Lookups
{
	public interface IProductLookupDataService
	{
		Task<IEnumerable<LookupItem>> GetProductLookupAsync();
	}
}