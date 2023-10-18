using SQLite;
using System.Windows;

namespace WPF012
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new SaveWindow(null);
            f.ShowDialog();
            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CustomerListView.SelectedItem as Customer;
            if(item == null)
            {
                MessageBox.Show("行を選択してください");
                return;
            }

            var f = new SaveWindow(item);
            f.ShowDialog();
            ReadDatabase();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null)
            {
                MessageBox.Show("行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();
            }
        }

        private void ReadDatabase()
        {
            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                CustomerListView.ItemsSource = connection.Table<Customer>().ToList();
            }
        }
    }
}
