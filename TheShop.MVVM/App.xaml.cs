using Autofac;
using System.Windows;
using TheShop.MVVM.Startup;

namespace TheShop.MVVM
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var bootstrapper = new Bootstrapper();
			var container = bootstrapper.Bootstrap();

			var mainWindow = container.Resolve<MainWindow>();
			mainWindow.Show();
		}
	}
}
