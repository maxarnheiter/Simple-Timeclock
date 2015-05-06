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
    /// Interaction logic for PTOPromptWindow.xaml
    /// </summary>
    public partial class PTOPromptWindow : Window
    {

        public int amount;
        public bool canceled;
        public string description;
        bool isAdd;


        public PTOPromptWindow()
        {
            InitializeComponent();
        }

        public PTOPromptWindow(bool isAdd)
        {
            this.isAdd = isAdd;

            InitializeComponent();
        }

    //Custom Methods

        private bool CheckInput()
        {
            int testInt;

            if (int.TryParse(amount_textbox.Text, out testInt))
                if (testInt > 0)
                    return true;

            return false;
        }

    //Interface Methods

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            canceled = true;
            this.Close();
        }

        private void submit_button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                int.TryParse(amount_textbox.Text, out amount);
                description = description_textbox.Text;
                this.Close();
            }
            else
                MessageBox.Show("Invalid input. Must be non-negative number that is greater than zero.");
        }

       
    }
}
