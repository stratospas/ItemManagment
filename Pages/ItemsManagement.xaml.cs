using ItemManagment.Models;
using ItemManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemManagment.Pages
{
    /// <summary>
    /// Interaction logic for ItemsManagement.xaml
    /// </summary>
    public partial class ItemsManagement : Page
    {
        public ObservableCollection<Item> items;
        public ItemsManagement()
        {
            InitializeComponent();
            items = new ObservableCollection<Item>(ItemServices.GetItems());
            ItemData.ItemsSource = items;
        }


        private void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            //var w = new Add_Item_Window();
            //var w = new Person_Profile(2);
            //w.Show();
            this.NavigationService.Navigate(new PersonManagement());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            items = new ObservableCollection<Item>(ItemServices.GetItems());
            ItemData.ItemsSource = items;
        }

        private void ItemData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ItemData.SelectedItem is DataRowView dataRowView)
            {
                var w = new Add_Item_Window();
                w.Show();
            }
        }
    }
}
