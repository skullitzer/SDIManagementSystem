using SDIManagementSystem.Business;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIManagementSystem.Data
{
    public static class CarXmlData
    {
        private static string GetFilePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Cars.Xml";
        }

        public static List<Car> Load()
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
                return new List<Car>();

            string fileContent = File.ReadAllText(filePath);
            if (fileContent == "")
                return new List<Car>();

            using (var reader = new StringReader(fileContent))
            {
                var serializer = new XmlSerializer(typeof(List<Car>));
                return (List<Car>)serializer.Deserialize(reader)!;
            }
        }

        public static void Save(List<Car> list)
        {
            string filePath = GetFilePath();
            using (var writer = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<Car>));
                serializer.Serialize(writer, list);
            }
        }
    }
}
