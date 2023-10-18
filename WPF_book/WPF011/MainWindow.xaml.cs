using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF011
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private int _index = 0;
        public MainWindow()
        {
            InitializeComponent();

            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });

            CustomerListView.ItemsSource = _customers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            //CustomerListView.ItemsSource = _customers;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filterList =
                _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }
    }
}
