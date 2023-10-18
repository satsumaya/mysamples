using SQLite;
using System.Windows;

namespace WPF012
{
    /// <summary>
    /// SaveWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SaveWindow : Window
    {
        private Customer _customer;
        public SaveWindow(Customer customer)
        {
            InitializeComponent();

            _customer = customer;

            if(customer != null)
            {
                this.NameTextBox.Text = customer.Name;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text.Trim().Length < 1)
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Customer>();
                if(_customer == null)
                {
                    connection.Insert(new Customer(NameTextBox.Text));
                }
                else
                {
                    connection.Update(new Customer(_customer.Id, NameTextBox.Text));
                }

                Close();
            }
        }
    }
}
