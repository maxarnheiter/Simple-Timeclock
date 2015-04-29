using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Collections.Specialized;

namespace SimpleTimeClock
{
    public class Company : INotifyPropertyChanged
    {

        //All events cascade up to this
        public delegate void CompanyChangedEventHandler();
        public event CompanyChangedEventHandler CompanyChanged;

        protected void OnCompanyChanged(object source, EventArgs e)
        {
            CompanyChangedEventHandler handler = CompanyChanged;
            
            if (handler != null)
                handler();
        }

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

        private string _name;
        public string name
        {
            get { return _name; }
            set 
            {
                if (value != _name) 
                {
                    _name = value;
                    OnPropertyChanged("name");
                }
            }
        }

        private string _adminPassword;
        public string adminPassword
        {
            get { return _adminPassword; }
            set
            {
                if (value != _adminPassword)
                {
                    _adminPassword = value;
                    OnPropertyChanged("adminPassword");
                }
            }
        }

        private string _exportPassword;
        public string exportPassword
        {
            get { return _exportPassword; }
            set
            {
                if (value != _exportPassword)
                {
                    _exportPassword = value;
                    OnPropertyChanged("exportPassword");
                }
            }
        }

        private string _exportEmail;
        public string exportEmail
        {
            get { return _exportEmail; }
            set
            {
                if (value != _exportEmail)
                {
                    _exportEmail = value;
                    OnPropertyChanged("exportEmail");
                }
            }
        }

        private readonly ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> employees
        {
            get { return _employees; }
        }

        public List<ClockAction> clockLog;

        public Company()
        {
            _employees = new ObservableCollection<Employee>();

            PropertyChanged += OnCompanyChanged;
            employees.CollectionChanged += OnCompanyChanged;

            foreach (Employee e in employees)
            {
                e.PropertyChanged += OnCompanyChanged;
                e.PropertyChanged += OnEmployeeClockAction;
            }
        }

        public Company(string newName, string adminPass)
        {
            adminPassword = adminPass;
            name = newName;

            _employees = new ObservableCollection<Employee>();

            PropertyChanged += OnCompanyChanged;
            employees.CollectionChanged += OnCompanyChanged;

            foreach (Employee e in employees)
            {
                e.PropertyChanged += OnCompanyChanged;
                e.PropertyChanged += OnEmployeeClockAction;
            }
        }

        public Employee AddEmployee(string emp_fname, string emp_lname, string emp_pword)
        {
            if (employees.Any(e => e.fname == emp_fname && e.lname == emp_lname))
                return null;

            Employee employee = new Employee(emp_fname, emp_lname, emp_pword);

            employee.PropertyChanged += OnCompanyChanged;
            employee.PropertyChanged += OnEmployeeClockAction;
            
            _employees.Add(employee);

            return employee;
        }

        public bool RemoveEmployee(Employee employee)
        {
            if (employees.Any(e => e.fname == employee.fname && e.lname == employee.lname))
            {
                employee.PropertyChanged -= OnCompanyChanged;
                employee.PropertyChanged -= OnEmployeeClockAction;

                _employees.Remove(employee);
                return true;
            }

            return false;
        }

        private void OnEmployeeClockAction(object source, EventArgs e)
        {
            PropertyChangedEventArgs args = e as PropertyChangedEventArgs;

            if (args.PropertyName == "status")
                Console.WriteLine("status change detected");
        }

    }
}
