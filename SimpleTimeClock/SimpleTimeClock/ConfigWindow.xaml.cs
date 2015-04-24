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
        Employee current;

        public ConfigWindow(Company company)
        {
            InitializeComponent();
            this.company = company;
            InitializeUI();

            company.EmployeesChanged += new Company.EmployeesChangedEventHandler(OnEmployeesChanged);
        }

        private void InitializeUI()
        {
            admin_password_passwordbox.Password = company.adminPassword;
            export_password_passwordbox.Password = company.exportPassword;
            export_email_textbox.Text = company.exportEmail;

            employees_listbox.DisplayMemberPath = "fullname";

            UpdateListBox();
        }


        private void UpdateListBox()
        {
            //Make sure the list contains employees in the company
            foreach (var employee in company.employees)
            {
                if(!employees_listbox.Items.Contains(employee))
                    employees_listbox.Items.Add(employee);
            }


            //Now lets make sure we don't have any false items in the list
            List<object> removeList = new List<object>();

            foreach (var item in employees_listbox.Items)
            {
                Employee employee = item as Employee;

                if (!company.employees.Contains(employee))
                    removeList.Add(item);
            }

            if (removeList.Count > 0)
                foreach (var item in removeList)
                    employees_listbox.Items.Remove(item);
                


            employees_listbox.Items.Refresh();
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

    //Export E-Mail

        private void export_email_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            company.exportEmail = export_email_textbox.Text;
        }

    //Employee ListBox

        private void employees_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((employees_listbox.SelectedItem as Employee) != current)
            {
                current = employees_listbox.SelectedItem as Employee;

                if (current != null)
                {
                    employee_fname_textbox.Text = current.fname;
                    employee_lname_textbox.Text = current.lname;
                    employee_password_passwordbox.Password = current.password;
                }
                else
                {
                    employee_fname_textbox.Text = null;
                    employee_lname_textbox.Text = null;
                    employee_password_passwordbox.Password = null;
                }

            }
        }

        private void OnEmployeesChanged()
        {
            UpdateListBox();
        }

    //Employee Password and Checkbox

        private void show_employee_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                employee_password_textbox.Text = current.password;

                employee_password_passwordbox.Visibility = Visibility.Hidden;
                employee_password_textbox.Visibility = Visibility.Visible;
            }
        }

        private void show_employee_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (employees_listbox.SelectedItem != null)
            {
                employee_password_passwordbox.Password = current.password;

                employee_password_passwordbox.Visibility = Visibility.Visible;
                employee_password_textbox.Visibility = Visibility.Hidden;
            }
        }

        private void employee_password_passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (employees_listbox.SelectedItem != null)
            {
                current.password = employee_password_passwordbox.Password;
            }
        }

        private void employee_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (employees_listbox.SelectedItem != null)
            {
                current.password = employee_password_textbox.Text;
            }
        }

    //Employee Name

        private void employee_fname_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (employees_listbox.SelectedItem != null)
            {
                current.fname = employee_fname_textbox.Text;
                UpdateListBox();
            }
        }

        private void employee_lname_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (employees_listbox.SelectedItem != null)
            {
                current.lname = employee_lname_textbox.Text;
                UpdateListBox();
            }
        }

    //Add Employee Button

        private void add_employee_button_Click(object sender, RoutedEventArgs e)
        {
            company.AddEmployee(new Employee("New", "Employee", "password"));

            employees_listbox.SelectedItem = company.employees.Find(emp => emp.fullname == "New Employee");
        }

    //Remove Employee Button

        private void remove_employee_button_Click(object sender, RoutedEventArgs e)
        {
            company.RemoveEmployee(current);

            employees_listbox.SelectedItem = null;
        }


    //Close Button

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


       
    }
}
