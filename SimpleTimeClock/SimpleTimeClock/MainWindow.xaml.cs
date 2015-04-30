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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTimeClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company company;

        ConfigWindow configWindow;

        Employee current_in;
        Employee current_out;

        public MainWindow(Company companyObj)
        {
            InitializeComponent();
            company = companyObj;
            InitializeUI();
        }

        private void InitializeUI()
        {
            company_name_label.Content = company.name;

            in_listbox.DisplayMemberPath = "fullname";
            out_listbox.DisplayMemberPath = "fullname";

            UpdateDateTimeLabels(null, null);
            
            UpdateListBoxes();
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            if (DoPasswordPrompt("Admin", company.adminPassword) == true)
            {
                configWindow = new ConfigWindow(company);

                if (configWindow.ShowDialog() == false)
                {
                    UpdateListBoxes();
                }
            }
        }

        private void UpdateListBoxes()
        {
            //Loop through all employees to potentially add
            foreach (Employee employee in company.employees)
            {
                if (employee.status == ClockStatus.In)
                {
                    if (!in_listbox.Items.Contains(employee))
                        in_listbox.Items.Add(employee);
                    if (out_listbox.Items.Contains(employee))
                        out_listbox.Items.Remove(employee);
                }
                if (employee.status == ClockStatus.Out)
                {
                    if (!out_listbox.Items.Contains(employee))
                        out_listbox.Items.Add(employee);
                    if (in_listbox.Items.Contains(employee))
                        in_listbox.Items.Remove(employee);
                }
            }
        }

        private void clock_in_button_Click(object sender, RoutedEventArgs e)
        {
            if (current_out != null)
            {
                if (DoPasswordPrompt(current_out.fullname, current_out.password) == true)
                {
                    current_out.ClockIn();
                    UpdateListBoxes();
                }
            }
        }

        private void clock_out_button_Click(object sender, RoutedEventArgs e)
        {
            if (current_in != null)
            {
                if (DoPasswordPrompt(current_in.fullname, current_in.password) == true)
                {
                    current_in.ClockOut();
                    UpdateListBoxes();
                }
            }
        }

        private void out_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (out_listbox.SelectedItem != null)
                current_out = out_listbox.SelectedItem as Employee;
            
        }

        private void in_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (in_listbox.SelectedItem != null)
                current_in = in_listbox.SelectedItem as Employee;
            
        }

        private bool DoPasswordPrompt(string displayName, string correctPassword)
        {
            PasswordWindow passwordWindow = new PasswordWindow(displayName);

            if (passwordWindow.ShowDialog() == false)
            {
                if (passwordWindow.password == correctPassword)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid password.");
                }
            }

            passwordWindow = null;
            return false;
        }

        private void UpdateDateTimeLabels(object source, EventArgs e)
        {
            current_date_label.Content = DateTime.Now.ToString("MM/dd/yyy");
            current_time_label.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
            dispatcher.Tick += new EventHandler(UpdateDateTimeLabels);
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Start();
        }

        private void settings_button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(DoPasswordPrompt("Export User", company.exportPassword) == true)
            {
                //TODO export via e-mail
            }
        }
      
    }
}
