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

        Employee _currentEmployee;
        Employee currentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                if (value != _currentEmployee)
                {
                    _currentEmployee = value;
                    OnCurrentEmployeeChanged();
                }
            }
        }

        PTOAction _currentPTOAction;
        PTOAction currentPTOAction
        {
            get { return _currentPTOAction; }
            set
            {
                if (value != _currentPTOAction)
                {
                    _currentPTOAction = value;
                    OnCurrentPTOActionChanged();
                }
            }
        }

        int _selectedMonth;
        int selectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                if (value != _selectedMonth)
                {
                    _selectedMonth = value;
                    OnSelectedMonthChanged();
                }
            }
        }


        int _selectedYear;
        int selectedYear
        {
            get { return _selectedYear; }
            set
            {
                if (value != _selectedYear)
                {
                    _selectedYear = value;
                    OnSelectedYearChanged();
                }
            }
        }

        public PTOWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public PTOWindow(Company company)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.company = company;

            company.CompanyChanged += UpdatePTOListBox;
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

        private void InitializePTOListBox()
        {
            pto_listbox.DisplayMemberPath = "formattedDate";
        }

        //Update Functions

        private void UpdatePTOListBox()
        {
            if (currentEmployee != null)
            {
                pto_listbox.Items.Clear();

                List<PTOAction> ptoActions = GetEmployeePTOActions(currentEmployee);

                if (ptoActions != null && ptoActions.Count > 0)
                {
                    foreach (PTOAction ptoAction in ptoActions)
                        pto_listbox.Items.Add(ptoAction);
                }
            }
            else
            {
                pto_listbox.Items.Clear();
            }
        }

        private void UpdateAddButton()
        {
            if (currentEmployee != null)
                add_button.IsEnabled = true;
            else
                add_button.IsEnabled = false;
        }

        private void UpdateRemoveButton()
        {
            if (currentPTOAction != null)
                remove_button.IsEnabled = true;
            else
                remove_button.IsEnabled = false;
        }

        private void UpdateDescriptionTextBox()
        {
            if (currentPTOAction != null)
                description_textbox.Text = currentPTOAction.description;
            else
                description_textbox.Clear();
        }

        private void UpdateMonthPTOLabel()
        {
            if (currentEmployee != null)
            {
                pto_month_label.Content = GetMonthPTO(currentEmployee, selectedYear, selectedMonth);
            }
        }

        private void UpdateYearPTOLabel()
        {
            if (currentEmployee != null)
            {
                pto_year_label.Content = GetYearPTO(currentEmployee, selectedYear);
            }
        }

        //Get Functions

        private List<PTOAction> GetEmployeePTOActions(Employee employee)
        {
            return company.ptoLog.Where(pa => pa.employeeId == employee.id).OrderBy(pa => pa.formattedDate).ToList();
        }

        private float GetMonthPTO(Employee employee, int year, int month)
        {
            float amount = 0;

            if (company.ptoLog.Count > 0)
            {
                amount = company.ptoLog.Where(pa => pa.employeeId == employee.id && pa.year == year && pa.month == month).Sum(pa => pa.PTOAmount);
            }

            return amount;
        }

        private float GetYearPTO(Employee employee, int year)
        {
            float amount = 0;

            if (company.ptoLog.Count > 0)
            {
                amount = company.ptoLog.Where(pa => pa.employeeId == employee.id && pa.year == year).Sum(pa => pa.PTOAmount);
            }

            return amount;
        }

    //Responsive Functions (On..)

        private void OnCurrentEmployeeChanged()
        {
            UpdatePTOListBox();
            UpdateAddButton();
            UpdateRemoveButton();
            UpdateMonthPTOLabel();
            UpdateYearPTOLabel();
        }

        private void OnCurrentPTOActionChanged()
        {
            UpdateDescriptionTextBox();
            UpdateRemoveButton();
        }

        private void OnSelectedMonthChanged()
        {
            UpdateMonthPTOLabel();
            UpdateYearPTOLabel();
        }

        private void OnSelectedYearChanged()
        {
            UpdateMonthPTOLabel();
            UpdateYearPTOLabel();
        }

        private void OnAddButtonClicked()
        {
            if(currentEmployee != null)
            if (PasswordWindow.DoPasswordPrompt("Export User", company.exportPassword))
            {
                PTOPromptWindow promptWindow = new PTOPromptWindow();

                if (promptWindow.ShowDialog() == false)
                {
                    if (promptWindow.canceled != true)
                    {
                        company.AddPTOAction(new PTOAction(DateTime.Now, promptWindow.amount, currentEmployee.fullname, currentEmployee.id, promptWindow.date.Day, promptWindow.date.Month, promptWindow.date.Year, promptWindow.description));
                    }
                }
            }
        }

        private void OnRemoveButtonClicked()
        {
            //TODO
        }


    //Interface methods

        private void pto_window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeMonthComboBox();
            InitializeYearComboBox();
            InitializeEmployeeListbox();
            InitializePTOListBox();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            OnAddButtonClicked();
        }

        private void remove_button_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveButtonClicked();
        }

        private void employee_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (employee_listbox.SelectedItem != null)
                currentEmployee = employee_listbox.SelectedItem as Employee;
            
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void month_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMonth = month_combobox.SelectedIndex + 1;
        }

        private void year_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedYear = int.Parse((year_combobox.SelectedItem as ComboBoxItem).Content.ToString());
        }

        private void pto_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pto_listbox.SelectedItem != null)
                currentPTOAction = pto_listbox.SelectedItem as PTOAction;
        }
    }
}
