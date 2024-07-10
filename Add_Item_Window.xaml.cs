using ItemManagment.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ItemManagment
{
    /// <summary>
    /// Interaction logic for Add_Item.xaml
    /// </summary>
    public partial class Add_Item_Window : Window
    {
        public Item? newItem;
        public Add_Item_Window()
        {
            InitializeComponent();
            using var db = new DataBaseContext();
            int newId = db.items.Count() + 1;
            newItem = new Item { Id = newId, Description = "", Internal_code = "", Serial_number = "" };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using var db = new DataBaseContext();
            try
            {
                db.Add<Item>(newItem);
                db.SaveChanges();
                Internal_code.IsEnabled = false;
                Description.IsEnabled = false;
                Sn.IsEnabled = false;
                Quantity.IsEnabled = false;
                Add_Button.Visibility = Visibility.Hidden;
                Ext_Button.Visibility = Visibility.Hidden;
                Ok_Button.Visibility = Visibility.Visible;
                Message.Content = "Το αντικείμενο προστέθηκε με επιτυχία!";
            }
            catch
            {
                Message.Content = "Παρουσιάστηκε σφάλμα. Προσπαθήστε ξανά.";
            }
            
        }

        private void Internal_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            newItem.Internal_code = Internal_code.Text.ToUpper();
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            newItem.Description = Description.Text.ToUpper();
        }

        private void Sn_TextChanged(object sender, TextChangedEventArgs e)
        {
            newItem.Serial_number = Sn.Text.ToUpper();
        }
    }
}
