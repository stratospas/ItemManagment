using ItemManagment.Models;
using ItemManagment.Services;
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
    }
}
