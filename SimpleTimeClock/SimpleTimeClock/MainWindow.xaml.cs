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

        public MainWindow(Company company)
        {
            InitializeComponent();
            this.company = company;
            InitializeUI();
        }

        private void InitializeUI()
        {
            company_name_label.Content = company.name;
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            configWindow = new ConfigWindow(company);

            if (configWindow.ShowDialog() == false)
            {
                //todo
            }

        }

      
    }
}
