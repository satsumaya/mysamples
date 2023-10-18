using System;
using System.Windows;

namespace WPF013
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

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Normal button click!!");
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "RepeatButton");
        }

        private void MyToggleBtton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("toggle button click:" + MyToggleBtton.IsChecked);
        }
    }
}
