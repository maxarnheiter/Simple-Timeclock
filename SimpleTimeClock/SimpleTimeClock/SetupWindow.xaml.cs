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
using Microsoft.Win32;

namespace SimpleTimeClock
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public Company company;

        NewCompanyWindow newCompanyWindow;

        public SetupWindow()
        {
            InitializeComponent();
        }

        private void load_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            
            if (fileDialog.ShowDialog() == true)
            {
                company = Company.Deserialize(fileDialog.FileName);

                if (company == null)
                    MessageBox.Show("Failed to open company file.");
                else
                    OpenMainWindow();
                
            }
        }

        private void create_new_button_Click(object sender, RoutedEventArgs e)
        {
            newCompanyWindow = new NewCompanyWindow();

            if (newCompanyWindow.ShowDialog() == false)
            {
                if (newCompanyWindow.newCompany != null)
                    OpenMainWindow();

                newCompanyWindow = null;
            }
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow(company);
            mainWindow.Show();

            company = null;
            this.Close();
        }
    }
}
