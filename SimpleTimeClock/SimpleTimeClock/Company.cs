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

    }
}
