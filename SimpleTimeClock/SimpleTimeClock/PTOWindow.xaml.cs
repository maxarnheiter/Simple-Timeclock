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
    /// Interaction logic for PTOWindow.xaml
    /// </summary>
    public partial class PTOWindow : Window
    {
        Company company;

        Employee current;

        int selectedMonth;
        int selectedYear;

        public PTOWindow()
        {
            InitializeComponent();
        }

        public PTOWindow(Company company)
        {
            InitializeComponent();
            this.company = company;
        }

    //Custom methods

        private void InitializeYearComboBox()
        {

            int currentYear = DateTime.Now.Year;

            ComboBoxItem currentYearBoxItem = null;

            for (int i = currentYear - 3; i <= currentYear + 4; i++)
            {
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = i.ToString();
                year_combobox.Items.Add(boxItem);

                if (i == currentYear)
                    currentYearBoxItem = boxItem;
            }

            year_combobox.SelectedItem = currentYearBoxItem;
        }

        private void InitializeMonthComboBox()
        {
            int currentMonth = DateTime.Now.Month;

            month_combobox.SelectedIndex = currentMonth - 1;
        }

        private void InitializeEmployeeListbox()
        {
            employee_listbox.DisplayMemberPath = "fullname";

            foreach (Employee employee in company.employees)
                employee_listbox.Items.Add(employee);

        }

        private void UpdatePTOLabel()
        {
            if (current != null)
            if (selectedMonth != 0)
            if (selectedYear != 0)
            {

            }
        }

    //Interface methods

        private void pto_window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeMonthComboBox();
            InitializeYearComboBox();
            InitializeEmployeeListbox();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                PTOPromptWindow promptWindow = new PTOPromptWindow(true);

                if (promptWindow.ShowDialog() == false)
                {
                    if (promptWindow.canceled != true)
                    {
                        company.AddPTOAction(new PTOAction(DateTime.Now, promptWindow.amount, current.fullname, selectedMonth, selectedYear, promptWindow.description));
                        UpdatePTOLabel();
                    }
                }
            }
        }

        private void remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                PTOPromptWindow promptWindow = new PTOPromptWindow(false);

                if (promptWindow.ShowDialog() == false)
                {
                    if (promptWindow.canceled != true)
                    {
                        company.AddPTOAction(new PTOAction(DateTime.Now, promptWindow.amount, current.fullname, selectedMonth, selectedYear, promptWindow.description));
                        UpdatePTOLabel();
                    }
                }
            }
        }

        private void employee_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employee_listbox.SelectedItem != null)
            {
                current = employee_listbox.SelectedItem as Employee;

                UpdatePTOLabel();
            }
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void month_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMonth = month_combobox.SelectedIndex + 1;
            UpdatePTOLabel();
        }

        private void year_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedYear = int.Parse((year_combobox.SelectedItem as ComboBoxItem).Content.ToString());
            UpdatePTOLabel();
        }
    }
}
