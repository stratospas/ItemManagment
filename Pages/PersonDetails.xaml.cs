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
    /// Interaction logic for PersonDetails.xaml
    /// </summary>
    public partial class PersonDetails : Page
    {
        public Person? person;
        public ObservableCollection<Department>? deps;

        public PersonDetails(Person? _person)
        {
            InitializeComponent();
            string title = "Στοιχεία", btn = "Ενημέρωση";

            if (_person == null)
            {
                person = new Person { Name = string.Empty, Lastname = string.Empty };
                title = "Προσθήκη";
                btn = "Προσθήκη";
                Delete.Visibility = Visibility.Collapsed;
            }
            else
                person = _person;

            Ιnitiliazer(title, btn , person);
        }

        public void Ιnitiliazer(string _title, string btn, Person p)
        {
            deps = new ObservableCollection<Department>(ServiceDepartment.Get_All());
            DepartmentsList.ItemsSource = deps;
            TitleBox.Text = _title;
            FirstName.Text = p.Name;
            LastName.Text = p.Lastname;

            if (p.Department != null)
            {
                foreach (var i in DepartmentsList.Items)
                {
                    var x = (Department)i;
                    if (x.DepartmentId == p.DepartmentId)
                    {
                        DepartmentsList.SelectedItem = i;
                        break;
                    }
                }
            }

            Submit.Content = btn;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Department d = (Department)DepartmentsList.SelectedItem;
            string message = "";

            if (FirstName.Text == "")
            {
                message += "Το πεδίο Όνομα είναι κενό.\n";
                FirstName.BorderBrush = Brushes.Red;
            }

            if (LastName.Text == "")
            {
                message += "Το πεδίο Επώνυμο είναι κενό.\n";
                LastName.BorderBrush = Brushes.Red;
            }


            if (d == null)
            {
                message += "Δεν έχει επιλεχθεί τμήμα.";
                DepartmentsList.BorderBrush = Brushes.Red;
            }


            if (message == "")
            {
                person.DepartmentId = d.DepartmentId;

                bool result = ServicePerson.Update(person);
                if (result)
                {
                    Message.Text = "Τα στοιχεία ενημερώθηκαν!";
                    Ok_btn.Visibility = Visibility.Visible;
                    Cancel.Visibility = Visibility.Hidden;
                    Submit.Visibility = Visibility.Hidden;
                }
                else
                    Message.Text = "Κάτι πήγε λάθος. Τα στοιχεία δεν αποθηκεύτηκαν.";
            }
            else
            {
                Message.Text = message;
            }



        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.Name = FirstName.Text;
            FirstName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFABADB3"));
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            person.Lastname = LastName.Text;
            LastName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFABADB3"));
        }

        private void DepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DepartmentsList.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFABADB3"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Ok_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PersonManagement());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var r = MessageBox.Show("Σίγουρα θέλετε να διαγράψετε την εγγραφή;", "Προσοχή!" ,MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                try
                {
                    bool del = ServicePerson.Delete(this.person.PersonId);
                    if (del == true)
                    {
                        MessageBox.Show("Η διαγραφή ολοκληρώθηκε!", " ", MessageBoxButton.OK);
                        this.NavigationService.Navigate(new PersonManagement());
                    }
                    else
                        MessageBox.Show("Η διαγραφή ΔΕΝ ολοκληρώθηκε!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Η διαγραφή ΔΕΝ ολοκληρώθηκε!{ex}");
                }
            }

        }
    }
}
