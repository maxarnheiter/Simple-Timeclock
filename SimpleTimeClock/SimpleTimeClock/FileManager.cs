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
    static class FileManager
    {
        public static Company OpenCompany(string path, FileStream fileStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            return (Company)serializer.Deserialize(fileStream);
        }

        public static void SaveCompany(Company company, FileStream fileStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Company));

            fileStream.SetLength(0);
            fileStream.Flush();

            serializer.Serialize(fileStream, company);
        }

    }
}
