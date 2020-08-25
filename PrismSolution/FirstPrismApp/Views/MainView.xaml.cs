using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace FirstPrismApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

        public MainView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            // regionManager.RegisterViewWithRegion("ContentRegion", typeof(SubView));

            _container = container;
            _regionManager = regionManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = _container.Resolve<SubView>();
            var region = _regionManager.Regions["ContentRegion"];
            region.Add(view);
        }
    }
}
