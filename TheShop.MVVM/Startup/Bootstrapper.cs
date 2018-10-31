using Autofac;
using Prism.Events;
using TheShop.Data.Lookups;
using TheShop.DataAccess;
using TheShop.MVVM.Data.Repositories;
using TheShop.MVVM.View.Services;
using TheShop.MVVM.ViewModel;

namespace TheShop.MVVM.Startup
{
	public class Bootstrapper
	{
		public IContainer Bootstrap()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

			builder.RegisterType<ProductDbContext>().AsSelf();

			builder.RegisterType<MainWindow>().AsSelf();

			builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

			builder.RegisterType<ProductViewModel>().AsSelf();
			builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
			builder.RegisterType<ProductDetailViewModel>().As<IProductDetailViewModel>();

			builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
			builder.RegisterType<ProductRepository>().As<IProductRepository>();

			return builder.Build();
		}
	}
}
