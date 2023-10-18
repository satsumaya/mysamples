using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPF010
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

            CustomerListView.ItemsSource = _customers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _customers.Add(new Customer { Id = ++_index, Name = "name" + _index, Phone = "phone" + _index });
            //CustomerListView.ItemsSource = _customers;
        }
    }
}
