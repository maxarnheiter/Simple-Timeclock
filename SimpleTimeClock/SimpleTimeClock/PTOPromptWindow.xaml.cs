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

        public DateTime date;
        public int amount;
        public bool canceled;
        public string description;


        public PTOPromptWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

    //Custom Methods

        private bool CheckDate()
        {
            if (pto_datepicker.SelectedDate != null)
            {
                date = (DateTime)pto_datepicker.SelectedDate;
                return true;
            }
            else
            {
                MessageBox.Show("Error: no selected date.");
                return false;
            }

        }

        private bool CheckAmount()
        {
            int testInt;

            if (int.TryParse(amount_textbox.Text, out testInt))
            {
                if (testInt > 0)
                {
                    amount = testInt;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error: PTO Amount must be a non-negative number greater than zero.");
                    return false;
                }
            }

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
            if (CheckAmount() && CheckDate())
            {
                description = description_textbox.Text;
                this.Close();
            }
        }

       
    }
}
