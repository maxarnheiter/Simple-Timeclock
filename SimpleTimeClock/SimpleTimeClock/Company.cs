using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SimpleTimeClock
{
    public class Company
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnNameChanged(_name);
                }
            }
        }

        public event EventHandler NameChanged;

        protected void OnNameChanged(EventArgs e)
        {
            EventHandler handler = NameChanged;
            if (handler != null)
                handler(this, e);
        }

        public List<Employee> employees;

        public string adminPassword;
        public string exportPassword;

        public string exportEmail;


        public Company()
        { }

        public Company(string newName, string adminPass)
        {
            adminPassword = adminPass;
            name = newName;
        }

        public bool AddEmployee(Employee employee)
        {
            if(employees.Exists(e => e.fname == employee.fname && e.lname == employee.lname))
                return false;
            
            employees.Add(employee);

            EmployeesChanged();

            return true;
        }

        public bool RemoveEmployee(Employee employee)
        {
            if (employees.Exists(e => e.fname == employee.fname && e.lname == employee.lname))
            {
                employees.Remove(employee);

                EmployeesChanged();
            }

            return false;
        }

    }
}
