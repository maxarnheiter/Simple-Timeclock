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
    /// Interaction logic for ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {

        Company company;

        int selectedMonth;
        int selectedYear;

        public ExportWindow()
        {
            InitializeComponent();
        }


        public ExportWindow(Company companyObj)
        {
            InitializeComponent();

            company = companyObj;
        }


        private void Export_Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeYearComboBox();
            InitializeMonthComboBox();

            export_email_label.Content = company.exportEmail;
        }

    //Interface Methods

        private void year_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selectedYear = int.Parse((year_combo_box.SelectedItem as ComboBoxItem).Content.ToString());
        }

        private void month_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMonth = month_combo_box.SelectedIndex + 1;
        }

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

            foreach (Employee employee in company.employees)
            {

                for (int day = 1; day <= daysInMonth; day++)
                {
                    float hoursWorked = 0;

                    List<ClockAction> dayClockActions = company.clockLog.Where(ca => ca.employeeId == employee.id
                                                                                && ca.time.Year == selectedYear
                                                                                && ca.time.Month == selectedMonth
                                                                                && ca.time.Day == day).OrderBy(ca => ca.time).ToList();

                    if (dayClockActions != null && dayClockActions.Count > 0)
                    {
                        
                        foreach (ClockAction clockAction in dayClockActions)
                        {
                            Console.WriteLine(clockAction.employeeId + " " + clockAction.employeeName + " " + clockAction.clockStatus + " " + clockAction.time);
                        }

                        if (dayClockActions.Count % 2 == 0)
                        {
                            //TODO
                        }
                        else
                        {
                            //uneven
                        }
                    }

                    

                        //print details each action

                    //print summary
                }

                // print month summary

                //foreach

                    //print details of pto action

                //get pto summary for this month and this year

               

            }
        }

    //Custom Methods

        private void InitializeYearComboBox()
        {

            int currentYear = DateTime.Now.Year;

            ComboBoxItem currentYearBoxItem = null;

            for (int i = currentYear - 3; i <= currentYear + 4; i++)
            {
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = i.ToString();
                year_combo_box.Items.Add(boxItem);

                if (i == currentYear)
                    currentYearBoxItem = boxItem;
            }

            year_combo_box.SelectedItem = currentYearBoxItem;
        }

        private void InitializeMonthComboBox()
        {
            int currentMonth = DateTime.Now.Month;

            month_combo_box.SelectedIndex = currentMonth - 1;
        }
        

    }
}
