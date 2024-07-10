using ItemManagment.Models;
using ItemManagment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace ItemManagment.Windows
{
    /// <summary>
    /// Interaction logic for Person_Profile.xaml
    /// </summary>
    public partial class Person_Profile : Window
    {
        public ObservableCollection<Department>? deps;
        public Person? person;
        
        public Person_Profile(int id)
        {
            InitializeComponent();

            person = ServicePerson.Get_By_Id(id);
            
            Ιnitiliazer("Στοιχεία Υπαλλήλου", "Ενημέρωση", person);


        }

        public Person_Profile()
        {
            InitializeComponent();
            person = new Person { Name = "", Lastname = "", Department = null };
            Ιnitiliazer("Προσθήκη Υπαλλήλου", "Προσθήκη", person);

        }

        public void Ιnitiliazer(string _title, string btn, Person? p)
        {
            deps = new ObservableCollection<Department>(ServiceDepartment.Get_All());
            DepartmentsList.ItemsSource = deps;
            this.Title = _title;
            FirstName.Text = p.Name;
            LastName.Text = p.Lastname;

            if (p.Department != null)
            {
                foreach( var i in DepartmentsList.Items )
                {
                    var x = (Department)i;
                    if( x.DepartmentId == p.DepartmentId )
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
            Department d = (Department) DepartmentsList.SelectedItem;
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


            if (message =="")
            {
                person.DepartmentId = d.DepartmentId;

                bool result = ServicePerson.Add_Person(person);
                if (result)
                    this.Close();

                Message.Content = "Κάτι πήγε λάθος. Τα στοιχεία δεν αποθηκεύτηκαν.";
            }
            else
            {
                Message.Content = message;
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
            this.Close();
        }
    }
}
