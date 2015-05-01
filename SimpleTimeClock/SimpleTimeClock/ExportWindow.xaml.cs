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
