using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTimeClock
{
    class Employee
    {
        public string fname = "";
        public string lname = "";

        public string fullname
        {
            get { return fname + " " + lname; }
        }

        public Employee(string f_name, string l_name)
        {
            this.fname = f_name;
            this.lname = l_name;
        }


    }
}
