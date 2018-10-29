using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Data.Lookups
{
	public interface ICategoryLookupDataService
	{
		Task<IEnumerable<LookupItem>> GetCategoryLookupAsync();
	}
}