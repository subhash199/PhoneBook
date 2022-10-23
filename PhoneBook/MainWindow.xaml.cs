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

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
            DatabaseServices.CreateTable();          
            List<Contact> contacts =  DatabaseServices.FetchContacts("").ToList();
            Contact_Box.ItemsSource = contacts;
        }

        private void AddContactClick(object sender, RoutedEventArgs e)
        {
            AddContact contactWindow = new AddContact();
            this.Close();
            contactWindow.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Contact contact = b.CommandParameter as Contact;
            Edit edit = new Edit(contact);
            this.Close();
            edit.Show();
        }


        private void Search_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Contact> contact = DatabaseServices.FetchContacts(Search_Box.Text).ToList();
            Contact_Box.ItemsSource = contact;
        }
    }
}
