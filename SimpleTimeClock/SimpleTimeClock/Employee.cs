using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimpleTimeClock
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private string _fname;
        public string fname
        {
            get { return _fname; }
            set
            {
                if (value != _fname)
                {
                    _fname = value;
                    OnPropertyChanged("fname");
                }
            }
        }

        private string _lname;
        public string lname
        {
            get { return _lname; }
            set
            {
                if (value != _lname)
                {
                    _lname = value;
                    OnPropertyChanged("lname");
                }
            }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("password");
                }
            }
        }

        private ClockStatus _status;
        public ClockStatus status
        {
            get { return _status; }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged("status");
                }
            }
        }

        public string fullname
        {
            get { return _fname + " " + _lname; }
        }

        public Employee()
        { }

        public Employee(string f_name, string l_name)
        {
            _fname = f_name;
            _lname = l_name;
        }

        public Employee(string f_name, string l_name, string pword)
        {
            _fname = f_name;
            _lname = l_name;
            _password = pword;
        }

        public void ClockIn()
        {
            status = ClockStatus.In;
        }

        public void ClockOut()
        {
            status = ClockStatus.Out;
        }


    }
}
