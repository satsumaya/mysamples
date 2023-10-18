using System.Windows;
using System.Windows.Controls;

namespace WPF015
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

        private void ARadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if(radioButton == CRadioButton)
            {

            }
            else if(radioButton == DRadioButton)
            {

            }
        }
    }
}
