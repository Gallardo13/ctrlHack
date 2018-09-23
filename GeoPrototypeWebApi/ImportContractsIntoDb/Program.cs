using System;
using System.IO;
using System.Xml.Serialization;

namespace ImportContractsIntoDb
{
    [Serializable]
    public class OKPD
    {
        string code { get; set; }
        string name { get; set; }
    }

    [Serializable]
    public class product
    {
        public int sid { get; set; }
        public OKPD OKPD { get; set; }
        public string name { get; set; }
        public decimal sum { get; set; }
    }

    [Serializable]
    public class contract
    {
        public int id { get; set; }
        public string publishDate { get; set; }
        public int versionNumber { get; set; }
        public DateTime signDate { get; set; }
        public long regNum { get; set; }
        public product[] products { get; set; }
    }

    public class exportVal
    {
        public contract contract { get; set; }
    }

    class Program
    {
        public static string WorkFolder { get; set; } = @"d:\qqq\Destination\q";

        static void Main(string[] args)
        {
            LoadFilesIntoDB();

            Console.WriteLine("Load complete!");
        }

        private static void LoadFilesIntoDB()
        {
            var files = Directory.GetFiles(WorkFolder, "*.xml");

            foreach (var fileName in files)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(exportVal));
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    var str = fileStream.Length;
                    exportVal result = (exportVal)serializer.Deserialize(fileStream);
                }
            }

        }
    }
}
