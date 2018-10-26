using Autofac;
using TheShop.MVVM.Data;
using TheShop.MVVM.ViewModel;

namespace TheShop.MVVM.Startup
{
	public class Bootstrapper
	{
		public IContainer Bootstrap()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<ProductViewModel>().AsSelf();
			builder.RegisterType<ProductDataService>().As<IProductDataService>();

			return builder.Build();
		}
	}
}
