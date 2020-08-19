using System.Windows;

namespace WpfChartApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // var x = Enumerable.Range(0, 1000).Select(i => i / 10.0).ToArray();
            // var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();

            var x = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var y = new int[] { 100, 98, 97, 90, 20, 10, 60, 70, 44, 56 };

            linegraph.Plot(x, y);
        }
    }

   
}
