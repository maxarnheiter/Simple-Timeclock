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

        NewCompanyWindow newCompanyWindow;

        public SetupWindow()
        {
            InitializeComponent();
            Dataset.openWindows.Add(this);
        }

        private void load_button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Dataset.openWindows.Count);

            OpenFileDialog fileDialog = new OpenFileDialog();
            

            if (fileDialog.ShowDialog() == true)
            {
                Console.WriteLine(fileDialog.FileName);
                //TODO
            }
        }

        private void create_new_button_Click(object sender, RoutedEventArgs e)
        {
            //Create a new company window and show it to the user
            if (newCompanyWindow == null)
            {
                newCompanyWindow = new NewCompanyWindow();

                //TODO listen to the window closing so we can set it to null so it gets GC'ed

                newCompanyWindow.Show();
            }
            //If one already exists, show that to the user
            else
                newCompanyWindow.Activate();
        }
    }
}
