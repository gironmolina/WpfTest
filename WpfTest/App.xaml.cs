using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using WpfTest.Services;
using WpfTest.Views;

namespace WpfTest
{
    internal partial class App : PrismApplication
    {
	    protected override void RegisterTypes(IContainerRegistry containerRegistry)
	    {
			containerRegistry.Register<IPrcSstService, PrcSstService>();
		}

	    protected override Window CreateShell()
	    {
			var shell = Container.Resolve<MainWindow>();
			return shell;
		}
    }
}
