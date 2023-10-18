using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfControlTemplateApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello! Template!");
        }
    }
}
