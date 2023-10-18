using System.Windows;

namespace WPF005
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content += "A";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "";
        }
    }
}
