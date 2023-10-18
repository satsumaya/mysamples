using System;
using System.Windows;

namespace WPF014
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

        private void MyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MyCheckBox_Checked:" + MyCheckBox.IsChecked);
        }

        private void MyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MyCheckBox_Unchecked:" + MyCheckBox.IsChecked);
        }

        private void MyCheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MyCheckBox_Indeterminate:" + MyCheckBox.IsChecked);
        }
    }
}
