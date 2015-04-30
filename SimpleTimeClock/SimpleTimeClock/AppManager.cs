using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SimpleTimeClock
{
    static class AppManager
    {

        static bool isFileOpen;
        static FileStream fileStream;
        static string filePath;
        static Company company;

        public static Company OpenCompany(string path)
        {
            if (isFileOpen)
            {
                MessageBox.Show("Error, file is already open.");
                return null;
            }
            else
            {

                XmlSerializer serializer = new XmlSerializer(typeof(Company));

                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                company = (Company)serializer.Deserialize(fileStream);
                company.ListenToEmployees();
                company.CompanyChanged += OnCompanyChange;

                filePath = path;

                return company;
            }
        }

        public static void SaveCompanyAs(Company companyObj, string path)
        {
            company = companyObj;
            company.CompanyChanged += OnCompanyChange;

            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            serializer.Serialize(fileStream, company);
        }

        public static void SaveCompany()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            fileStream.SetLength(0);
            fileStream.Flush();

            serializer.Serialize(fileStream, company);
        }

        public static void CloseCompany()
        {
            //TODO
        }

        static void OnCompanyChange()
        {
            SaveCompany();
        }

    }
}
