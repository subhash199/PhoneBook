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

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private Contact contact;
        private string id;
        public Edit(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            id = DatabaseServices.fetchRowId(contact.firstName, contact.lastName, contact.number);
            PopulateDetails();
        }

        private void PopulateDetails()
        {
            FirstName_Box.Text = contact.firstName;
            LastName_Box.Text = contact.lastName;
            Phone_Box.Text = contact.number;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName_Box.Text;
            string lastName = LastName_Box.Text;
            string phone = Phone_Box.Text;

            bool result = ValidateEntry(firstName, lastName, phone);
            if (result)
            {
         

                bool isSuccess = DatabaseServices.Update(id,firstName, lastName, phone);
                if (isSuccess)
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    Error_Box.Text = "Not updated!";
                }
            }
            else
            {
                Error_Box.Text = "Please Enter Valid Details: Names should only contain letter, Phone should only" +
                    "be numbers and 11 digits in length";
            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseServices.Delete(id);
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
        private bool ValidateEntry(string fName, string lName, string pPhone)
        {
            bool isValid = true;

            if (fName.Any(c => !char.IsLetter(c)) || lName.Any(c => !char.IsLetter(c)) || pPhone.Any(c => !char.IsDigit(c)) || pPhone.Length != 11)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
