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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        public ExportWindow(Company companyObj)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            company = companyObj;
        }


        private void Export_Window_Loaded(object sender, RoutedEventArgs e)
        {
            export_email_label.Content = company.exportEmail;
        }

    //Interface Methods

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            Exporter exporter = new Exporter();

            DateTime? start = from_datepicker.SelectedDate;
            DateTime? end = to_datepicker.SelectedDate;

            if(start != null && end != null)
                exporter.Export(company, (DateTime)start, (DateTime)end);
        }
        

    }
}
