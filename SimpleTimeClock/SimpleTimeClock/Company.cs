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

        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> employees
        {
            get { return _employees; }
        }

        private ObservableCollection<ClockAction> _clockLog;

        public ObservableCollection<ClockAction> clockLog
        {
            get { return _clockLog; }
        }

        private ObservableCollection<PTOAction> _ptoLog;

        public ObservableCollection<PTOAction> ptoLog
        {
            get { return _ptoLog; }
        }

        //Called when we deserialize from XML
        public Company()    
        {
            _employees = new ObservableCollection<Employee>();
            _clockLog = new ObservableCollection<ClockAction>();
            _ptoLog = new ObservableCollection<PTOAction>();

            PropertyChanged += OnCompanyChanged;
            employees.CollectionChanged += OnCompanyChanged;
            clockLog.CollectionChanged += OnCompanyChanged;
            ptoLog.CollectionChanged += OnCompanyChanged;
        }

        //Called when we create a new Company object from the GUI
        public Company(string newName, string adminPass)
        {
            adminPassword = adminPass;
            name = newName;

            _employees = new ObservableCollection<Employee>();
            _clockLog = new ObservableCollection<ClockAction>();
            _ptoLog = new ObservableCollection<PTOAction>();

            PropertyChanged += OnCompanyChanged;
            employees.CollectionChanged += OnCompanyChanged;
            clockLog.CollectionChanged += OnCompanyChanged;
            ptoLog.CollectionChanged += OnCompanyChanged;
        }

        public void ListenToEmployees()
        {
            foreach (Employee e in employees)
            {
                e.PropertyChanged += OnCompanyChanged;
                e.PropertyChanged += OnEmployeeClockAction;
            }
        }

        public void AddPTOAction(PTOAction ptoAction)
        {
            _ptoLog.Add(ptoAction);
        }

        public Employee AddEmployee(string emp_fname, string emp_lname, string emp_pword)
        {
            if (employees.Any(e => e.fname == emp_fname && e.lname == emp_lname))
                return null;

            int nextHighestId;

            if (employees.Count == 0)
                nextHighestId = 0;
            else
                nextHighestId = employees.Max(e => e.id) + 1;

            Employee employee = new Employee(nextHighestId, emp_fname, emp_lname, emp_pword);

            employee.PropertyChanged += OnCompanyChanged;
            employee.PropertyChanged += OnEmployeeClockAction;
            
            _employees.Add(employee);

            return employee;
        }

        public bool RemoveEmployee(Employee employee)
        {
            if (employees.Any(e => e.id == employee.id))
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
            {
                Employee employee = source as Employee;
                ClockAction clockAction = new ClockAction(DateTime.Now, employee.status, employee.fullname, employee.id);
                _clockLog.Add(clockAction);
            }
        }

    }
}
