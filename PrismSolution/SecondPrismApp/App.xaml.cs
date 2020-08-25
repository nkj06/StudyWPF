using Prism.Ioc;
using Prism.Unity;
using SecondPrismApp.Views;
using System.Windows;

namespace SecondPrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {}
    }
}
