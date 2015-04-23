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
        public string name = "";

        public List<Employee> employees;

        public string adminPassword;
        public string exportPassword;

        public string exportEMail;

        public event EmployeesChangedEventHandler EmployeesChanged;

        public Company()
        { }

        public Company(string newName, string adminPass)
        {
            adminPassword = adminPass;
            name = newName;
        }

        public static void Serialize(Company company, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamWriter writer = new StreamWriter(path);

            serializer.Serialize(writer, company);

            writer.Close();
        }

        public static Company Deserialize(string path)
        {
            Company company;

            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            FileStream fileStream = new FileStream(path, FileMode.Open);

            company = (Company)serializer.Deserialize(fileStream);

            return company;
        }

        public delegate void EmployeesChangedEventHandler();

        public bool AddEmployee(Employee employee)
        {
            if(!employees.Exists(e => e.fname == employee.fname && e.lname == employee.lname))
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
