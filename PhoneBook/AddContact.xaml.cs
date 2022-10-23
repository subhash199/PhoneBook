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
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void CreateContact_Btn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName_Box.Text;
            string lastName = LastName_Box.Text;
            string phone = Phone_Box.Text;

            bool result = ValidateEntry(firstName, lastName, phone);
            if(result)
            {
                bool isSuccess = DatabaseServices.Insert(firstName, lastName, phone);
                if (isSuccess)
                {                    
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                else
                {
                    Error_Box.Text = "Contact insert error!";
                }
            }
            else
            {
                Error_Box.Text = "Please Enter Valid Details: Names should only contain letter, Phone should only" +
                    "be numbers and 11 digits in length";
            }
        }

        private bool ValidateEntry(String fName, string lName, string pPhone)
        {
            bool isValid = true;

            if(fName.Any(c => !char.IsLetter(c))|| lName.Any(c=>!char.IsLetter(c))||pPhone.Any(c=>!char.IsDigit(c))||pPhone.Length!=11)
            {
                isValid = false;
            }
            
            return isValid;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
