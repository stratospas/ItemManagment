using ItemManagment.Models;
using ItemManagment.Services;
using ItemManagment.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PersonManagement.xaml
    /// </summary>
    public partial class PersonManagement : Page
    {
        public ObservableCollection<Person> people;
        public PersonManagement()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>(ServicePerson.Get_All());
            peopleList.ItemsSource = people;
        }

        private void peopleList_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            if(peopleList.SelectedItem != null)
                this.NavigationService.Navigate(new PersonDetails((Person)peopleList.SelectedItem));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if( searchBox.Text == "" )
            {
                peopleList.ItemsSource = people;
            }
            else
            {
                var p = new ObservableCollection<Person>(ServicePerson.Search(searchBox.Text.ToUpper()));
                peopleList.ItemsSource = p;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PersonDetails(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
