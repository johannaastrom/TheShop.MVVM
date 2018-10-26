using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheShop.MVVM.ViewModel
{
	public class ViewModelBAse : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
