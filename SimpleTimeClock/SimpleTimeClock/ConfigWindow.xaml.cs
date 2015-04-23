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

namespace SimpleTimeClock
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {

        Company company;

        public ConfigWindow(Company company)
        {
            InitializeComponent();
            this.company = company;
            InitializeUI();
        }

        private void InitializeUI()
        {
            admin_password_passwordbox.Password = company.adminPassword;
            export_password_passwordbox.Password = company.exportPassword;
        }




    //Admin Password 

        private void show_admin_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            admin_password_textbox.Text = company.adminPassword;

            admin_password_passwordbox.Visibility = Visibility.Hidden;
            admin_password_textbox.Visibility = Visibility.Visible;
        }

        private void show_admin_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            admin_password_passwordbox.Password = company.adminPassword;

            admin_password_passwordbox.Visibility = Visibility.Visible;
            admin_password_textbox.Visibility = Visibility.Hidden;
        }

        private void admin_password_passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            company.adminPassword = admin_password_passwordbox.Password;
        }

        private void admin_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            company.adminPassword = admin_password_textbox.Text;
        }



    //Export Password

        private void show_export_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            export_password_textbox.Text = company.exportPassword;

            export_password_textbox.Visibility = Visibility.Visible;
            export_password_passwordbox.Visibility = Visibility.Hidden;
        }

        private void show_export_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            export_password_passwordbox.Password = company.exportPassword;

            export_password_textbox.Visibility = Visibility.Hidden;
            export_password_passwordbox.Visibility = Visibility.Visible;
        }

        private void export_password_passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            company.exportPassword = export_password_passwordbox.Password;
            Console.WriteLine(company.exportPassword);
        }

        private void export_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            company.exportPassword = export_password_textbox.Text;
            Console.WriteLine(company.exportPassword);
        }



        private void show_user_checkbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void show_user_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void add_employee_button_Click(object sender, RoutedEventArgs e)
        {
            //Dataset.company.AddEmployee(new Employee("New", "Employee", "password"));
        }

        private void remove_employee_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void user_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        



       
    }
}
