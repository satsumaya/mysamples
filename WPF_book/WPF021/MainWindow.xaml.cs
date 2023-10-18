using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF021
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Dto> _dtos = new ObservableCollection<Dto>();

        public MainWindow()
        {
            InitializeComponent();

            _dtos.Add(new Dto("Images/A.jpeg", "Shinichi ONO"));
            _dtos.Add(new Dto("Images/B.jpeg", "Jyunta INAMOTO"));
            _dtos.Add(new Dto("Images/C.jpeg", "Naotaro TAKAHARA"));
            MyListBox.ItemsSource = _dtos;
            SingleRadioButton.IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(SingleRadioButton.IsChecked.Value)
            {
                MyListBox.SelectionMode = SelectionMode.Single;
            }
            else if (ExtendedRadioButton.IsChecked.Value)
            {
                MyListBox.SelectionMode = SelectionMode.Extended;
            }
            else
            {
                MyListBox.SelectionMode = SelectionMode.Multiple;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public sealed class Dto
    {
        public Dto(string fileName, string name)
        {
            FileName = fileName;
            Name = name;
        }

        public string FileName { get; set; }
        public string Name { get; set; }
    }
}
