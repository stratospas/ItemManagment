using ItemManagment.Models;
using ItemManagment.Services;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ItemManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Item> items;
        public string TesterString = "tester";
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Item>(ItemServices.GetItems());
            ItemData.ItemsSource = items;
            
        }

        private void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            var w = new Add_Item_Window();
            w.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            items = new ObservableCollection<Item>(ItemServices.GetItems());
            ItemData.ItemsSource = items;
        }

        private void ItemData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(ItemData.SelectedItem is DataRowView dataRowView)
            {
                var w = new Add_Item_Window();
                w.Show();
            }
        }
    }
}