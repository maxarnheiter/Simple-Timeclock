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
using Microsoft.Win32;
using System.IO;

namespace SimpleTimeClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool isFileOpen;
        FileStream fileStream;
        string filePath;


        Company _company;
        Company company
        {
            get { return _company; }
            set
            {
                if (value != _company)
                {
                    _company = value;
                    CompanyChanged();
                }
            }
        }

        event Action CompanyChanged;

        Employee _current;
        Employee current
        {
            get { return _current; }
            set
            {
                if (value != _current)
                {
                    _current = value;
                    CurrentEmployeeChanged();
                }
            }
        }

        event Action CurrentEmployeeChanged;

        ConfigWindow configWindow;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            CompanyChanged += OnCompanyChanged;
            CurrentEmployeeChanged += OnCurrentEmployeeChanged;


            in_listbox.DisplayMemberPath = "fullname";
            out_listbox.DisplayMemberPath = "fullname";

            UpdateDateTimeLabels(null, null);
        }

    //Custom methods

        private void OnCompanyChanged()
        {
            if (company != null)
            {
                company_name_label.Content = company.name;

                company.CompanyChanged += OnCompanyDataChanged;
            }
            else
            {
                company_name_label.Content = "NO COMPANY LOADED";
            }

            UpdateListBoxes();
        }

        private void OnCompanyDataChanged()
        {
            FileManager.SaveCompany(company, fileStream);
            UpdateListBoxes();
        }

        private void OnCurrentEmployeeChanged()
        {
            if (current == in_listbox.SelectedItem)
            {
                out_listbox.SelectedItem = null;
            }

            if (current == out_listbox.SelectedItem)
            {
                in_listbox.SelectedItem = null;
            }
        }

        private void UpdateListBoxes()
        {
            if (company != null)
            {
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

                    in_listbox.Items.Refresh();
                    out_listbox.Items.Refresh();
                }
            }
            else
            {
                in_listbox.Items.Clear();
                out_listbox.Items.Clear();
            }
        }

        private void UpdateDateTimeLabels(object source, EventArgs e)
        {
            current_date_label.Content = DateTime.Now.ToString("MM/dd/yyy");
            current_time_label.Content = DateTime.Now.ToString("HH:mm:ss");
        }

    //Methods called by interface

        private void clock_in_button_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (PasswordWindow.DoPasswordPrompt(current.fullname, current.password) == true)
                {
                    current.ClockIn();
                    UpdateListBoxes();
                }
            }
        }

        private void clock_out_button_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (PasswordWindow.DoPasswordPrompt(current.fullname, current.password) == true)
                {
                    current.ClockOut();
                    UpdateListBoxes();
                }
            }
        }

        private void out_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (out_listbox.SelectedItem != null)
            {
                current = out_listbox.SelectedItem as Employee;

                clock_in_image.Visibility = Visibility.Visible;
            }
            else
            {
                clock_in_image.Visibility = Visibility.Hidden;
            }
            
        }

        private void in_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (in_listbox.SelectedItem != null)
            {
                current = in_listbox.SelectedItem as Employee;

                clock_out_image.Visibility = Visibility.Visible;
            }
            else
            {
                clock_out_image.Visibility = Visibility.Hidden;
            }
            
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcher = new System.Windows.Threading.DispatcherTimer();
            dispatcher.Tick += new EventHandler(UpdateDateTimeLabels);
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Start();
        }

        private void clock_in_image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PasswordWindow.DoPasswordPrompt(current.fullname, current.password) == true)
            {
                current.ClockIn();
            }
        }

        private void clock_out_image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PasswordWindow.DoPasswordPrompt(current.fullname, current.password) == true)
            {
                current.ClockOut();
            }
        }

        private void open_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (!isFileOpen)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                if (fileDialog.ShowDialog() == true)
                {
                    filePath = fileDialog.FileName;

                    fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                    company = FileManager.OpenCompany(filePath, fileStream);

                    if (company == null)
                    {
                        fileStream.Close();
                        filePath = null;

                        MessageBox.Show("Failed to open company file.");
                    }

                    isFileOpen = true;
                    company.ListenToEmployees();    //Secret socialist statement
                }

            }
            else
            {
                MessageBox.Show("Must close current company file.");
            }
        }

        private void create_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (!isFileOpen)
            {
                NewCompanyWindow newCompanyWindow = new NewCompanyWindow();

                if (newCompanyWindow.ShowDialog() == false)
                {
                    company = new Company(newCompanyWindow.newCompanyName, newCompanyWindow.adminPassword);

                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.FileName = company.name + ".xml";
                    saveDialog.Filter = "XML Files (*.xml)|*.xml";


                    if (saveDialog.ShowDialog() == true)
                    {
                        filePath = saveDialog.FileName;
                        fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                        FileManager.SaveCompany(company, fileStream);
                    }

                    MessageBox.Show("Company file created successfully.");

                    isFileOpen = true;
                    company.ListenToEmployees();
                }
            }
            else
            {
                MessageBox.Show("Must close current company file.");
            }
        }

        private void close_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (isFileOpen)
            {
                fileStream.Close();
                filePath = null;
                company = null;
                isFileOpen = false;
            }
        }

        private void settings_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (isFileOpen)
            {
                if (PasswordWindow.DoPasswordPrompt("Admin", company.adminPassword) == true)
                {
                    configWindow = new ConfigWindow(company);

                    if (configWindow.ShowDialog() == false)
                    {
                        UpdateListBoxes();
                    }
                }
            }
        }

        private void export_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (isFileOpen)
            {
                if (PasswordWindow.DoPasswordPrompt("Export User", company.exportPassword) == true)
                {
                    ExportWindow exportWindow = new ExportWindow(company);

                    if (exportWindow.ShowDialog() == false)
                    {
                        //do something
                    }

                }
            }
        }

        private void pto_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if (isFileOpen)
            {
                PTOWindow ptoWindow = new PTOWindow(company);

                if (ptoWindow.ShowDialog() == false)
                {
                    //do something
                }
            }
        }

        
    }
}
