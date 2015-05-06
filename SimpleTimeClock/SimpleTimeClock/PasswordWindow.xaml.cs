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
            password_box.Focus();
        }

        public PasswordWindow(string userName)
        {
            InitializeComponent();
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
    }
}
