using MahApps.Metro.Controls;
using System.Windows.Input;
using ThirdCaliburnApp.ViewModels;

namespace ThirdCaliburnApp.Views  // Views 안쓰면 InitializeComponent(); 오류남
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Salary_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Commons.IsNumpric(e.Text);
        }
    }
}
