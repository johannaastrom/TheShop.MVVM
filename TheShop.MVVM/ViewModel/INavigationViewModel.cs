using System.Threading.Tasks;

namespace TheShop.MVVM.ViewModel
{
	public interface INavigationViewModel
	{
		Task LoadAsync();
	}
}