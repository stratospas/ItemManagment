﻿using ItemManagment.Models;
using ItemManagment.Pages;
using ItemManagment.Services;
using ItemManagment.Windows;
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

        //public ObservableCollection<Item> items;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ItemsManagement());
            
        }

        

    }
}