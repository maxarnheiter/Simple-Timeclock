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

        public static Company OpenCompany(string path)
        {
            if (isFileOpen)
            {
                MessageBox.Show("Error, file is already open.");
                return null;
            }
            else
            {
                Company company;

                XmlSerializer serializer = new XmlSerializer(typeof(Company));

                fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                company = (Company)serializer.Deserialize(fileStream);

                filePath = path;

                return company;
            }
        }

        public static void SaveCompanyAs(Company company, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamWriter writer = new StreamWriter(path);

            serializer.Serialize(writer, company);

            writer.Close();
        }

        public static void SaveCompany(Company company)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            StreamWriter writer = new StreamWriter(filePath);

            serializer.Serialize(writer, company);

            writer.Close();
        }

        public static void CloseCompany()
        {
            //TODO
        }

    }
}
