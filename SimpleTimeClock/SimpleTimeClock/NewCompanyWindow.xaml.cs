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
using Microsoft.Win32;

namespace SimpleTimeClock
{
    /// <summary>
    /// Interaction logic for NewCompanyWindow.xaml
    /// </summary>
    public partial class NewCompanyWindow : Window
    {

        public Company newCompany;

        string newCompanyName = "";
        string adminPassword = "";
        string adminPasswordRepeat = "";

        public NewCompanyWindow()
        {
            InitializeComponent();
        }

        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            //Check if passwords match and company name is not blank
            if (newCompanyName == "")
            {
                MessageBox.Show("Company name cannot be left empty.");
                return;
            }
            if (adminPassword != adminPasswordRepeat)
            {
                MessageBox.Show("Passwords must match.");
                return;
            }

            //Create the new company object
            newCompany = new Company(newCompanyName, adminPassword);

            //Create and configure the save file dialog
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = newCompany.name + ".xml";
            saveDialog.Filter = "XML Files (*.xml)|*.xml";

            //Save the file when we get a path
            if(saveDialog.ShowDialog() == true)
            {
                AppManager.SaveCompanyAs(newCompany, saveDialog.FileName);
            }

            //Show success, and close
            MessageBox.Show("Company file created successfully.");
            this.Close();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Show passwords
        private void show_passwords_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            admin_password_textbox.Text = adminPassword;
            admin_password_repeat_textbox.Text = adminPasswordRepeat;

            admin_password_textbox.Visibility = Visibility.Visible;
            admin_password_repeat_textbox.Visibility = Visibility.Visible;

            admin_password_passwordbox.Visibility = Visibility.Hidden;
            admin_password_repeat_passwordbox.Visibility = Visibility.Hidden;

        }
        //Hide passwords
        private void show_passwords_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            admin_password_passwordbox.Password = adminPassword;
            admin_password_repeat_passwordbox.Password = adminPasswordRepeat;

            admin_password_textbox.Visibility = Visibility.Hidden;
            admin_password_repeat_textbox.Visibility = Visibility.Hidden;

            admin_password_passwordbox.Visibility = Visibility.Visible;
            admin_password_repeat_passwordbox.Visibility = Visibility.Visible;

        }

        private void company_name_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newCompanyName = company_name_textbox.Text;
        }

        private void admin_password_passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            adminPassword = admin_password_passwordbox.Password;
        }

        private void admin_password_repeat_passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            adminPasswordRepeat = admin_password_repeat_passwordbox.Password;
        }

        private void admin_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            adminPassword = admin_password_textbox.Text;
        }

        private void admin_password_repeat_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            adminPasswordRepeat = admin_password_repeat_textbox.Text;
        }




    

    }
}
