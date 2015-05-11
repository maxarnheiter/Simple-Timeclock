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
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {

        public string password;
        public bool canceled;

        public PasswordWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            password_box.Focus();
        }

        public PasswordWindow(string userName)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            user_name_label.Content = userName;
            password_box.Focus();
        }

        private void submit_button_Click(object sender, RoutedEventArgs e)
        {
            password = password_box.Password;
            this.Close();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            password = password_box.Password;
            this.Close();
        }

        private void password_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                password = password_box.Password;
                this.Close();
            }
           
        }


    //Static call
        public static bool DoPasswordPrompt(string displayName, string correctPassword)
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
    }
}
