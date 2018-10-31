using Prism.Commands;
using Prism.Events;
using System.Windows.Input;
using TheShop.MVVM.Event;

namespace TheShop.MVVM.ViewModel
{
	public class NavigationItemViewModel : ViewModelBase
	{
		private string _displayProduct { get; set; }
		private IEventAggregator _eventAggregator;

		public NavigationItemViewModel(int id, string displayProduct, IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
			Id = id;
			DisplayProduct = displayProduct;

			OpenProductDetailViewCommand = new DelegateCommand(OnOpenProductDetailView);
		}

		public int Id { get; set; }

		public string DisplayProduct
		{
			get { return _displayProduct; }
			set
			{
				_displayProduct = value;
				OnPropertyChanged();
			}
		}

		public ICommand OpenProductDetailViewCommand { get; }

		private void OnOpenProductDetailView()
		{
			_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
				.Publish(Id);
		}
	}
}
