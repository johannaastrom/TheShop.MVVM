namespace TheShop.MVVM.ViewModel
{
	public class NavigationItemViewModel : ViewModelBase
	{
		private string _displayProduct { get; set; }

		public NavigationItemViewModel(int id, string displayProduct)
		{
			Id = id;
			DisplayProduct = displayProduct;
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

	}
}
