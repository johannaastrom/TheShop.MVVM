using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TheShop.MVVM.Event;
using TheShop.MVVM.View.Services;

namespace TheShop.MVVM.ViewModel
{
	public class ProductViewModel : ViewModelBase
	{
		private IEventAggregator _eventAggregator;
		private Func<IProductDetailViewModel> _productDetailViewModelCreator;
		private IMessageDialogService _messageDialogService;
		private IProductDetailViewModel _productDetailViewModel;

		public ProductViewModel(INavigationViewModel navigationViewModel, Func<IProductDetailViewModel> productViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
		{
			_eventAggregator = eventAggregator;
			_productDetailViewModelCreator = productViewModelCreator;
			_messageDialogService = messageDialogService;

			_eventAggregator.GetEvent<OpenProductDetailViewEvent>()
				.Subscribe(OnOpenProductDetailView);

			NavigationViewModel = navigationViewModel;

			CreateNewProductCommand = new DelegateCommand(OnCreateNewProductExecute);
		}

		public async Task LoadAsync()
		{
			await NavigationViewModel.LoadAsync();
		}

		public ICommand CreateNewProductCommand { get; }

		public INavigationViewModel NavigationViewModel { get; }

		public IProductDetailViewModel ProductDetailViewModel
		{
			get { return _productDetailViewModel; }
			private set
			{
				_productDetailViewModel = value;
				OnPropertyChanged();
			}
		}

		private async void OnOpenProductDetailView(int? productId)
		{
			if (ProductDetailViewModel!=null && ProductDetailViewModel.HasChanges)
			{
				var result = _messageDialogService.ShowOkCancelDialog("You have made changes. Navigate away?", "Question");
				if (result == MessageDialogResult.Cancel)
				{
					return;
				}

			}
			ProductDetailViewModel = _productDetailViewModelCreator();
			await ProductDetailViewModel.LoadAsync(productId);
		}

		private void OnCreateNewProductExecute()
		{
			OnOpenProductDetailView(null);
		}
	}
}
