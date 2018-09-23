using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace LoadContracts
{
    class Program
    {
        public static Uri ServerUri { get; set; } = new Uri(
            "ftp://sv3.surayfer.com/fcs_regions/Kaliningradskaja_obl/contracts/currMonth/"
            //"ftp://ftp.zakupki.gov.ru/fcs_regions/Kaliningradskaja_obl/contracts/currMonth/";
            );

        public static string TemporaryFolderToDownload { get; set; } = @"d:\qqq\Download";

        public static string TemporaryFolderToDecompress { get; set; } = @"d:\qqq\Decompress";

        public static string DestinationFolder { get; set; } = @"d:\qqq\Destination";

        public static string UserName { get; set; } = "free";

        public static string UserPass { get; set; } = "free";

        private static FtpWebRequest GetFtpRequest(Uri serverUri, string ftpMethod)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);

            request.KeepAlive = true;
            request.UsePassive = true;
            request.UseBinary = true;

            request.Method = ftpMethod;
            request.Credentials = new NetworkCredential(UserName, UserPass);

            return request;
        }

        private static IEnumerable<string> GetFilesInDirectory()
        {
            var retVal = new List<string>();

            var request = GetFtpRequest(ServerUri, WebRequestMethods.Ftp.ListDirectory);

            using (var response = (FtpWebResponse)request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("Загружаем список файлов с FTP");

                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    retVal.Add(line);
                }
            }

            return retVal;
        }

        public static byte[] ReadAllBytes(BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }

        private static void DownloadFromFtp(IEnumerable<string> files)
        {
            foreach (var fileName in files)
            {
                Console.Write($"Загружаем файл: {fileName}...");

                var request = GetFtpRequest(new Uri(ServerUri, fileName), WebRequestMethods.Ftp.DownloadFile);

                var destinationFileName = new FileInfo($@"{TemporaryFolderToDownload}\{fileName}");

                // Read the file from the server & write to destination                
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) // Error here
                using (var responseStream = response.GetResponseStream())
                using (var reader = new BinaryReader(responseStream))
                using (var destination = new BinaryWriter(File.Open(destinationFileName.FullName, FileMode.CreateNew)))
                {
                    destination.Write(ReadAllBytes(reader));
                    destination.Flush();
                }

                Console.WriteLine(" done!");
            }
        }

        private static void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
                file.Delete();

            foreach (DirectoryInfo dir in directoryInfo.EnumerateDirectories())
                dir.Delete(true);
        }

        private static void EmptyTemporaryFolders()
        {
            EmptyFolder(new DirectoryInfo(TemporaryFolderToDecompress));
            EmptyFolder(new DirectoryInfo(TemporaryFolderToDownload));
        }

        private static void DecompressDownloadedFiles(FileInfo fileToDecompress)
        {
            // free decompress-folder
            EmptyFolder(new DirectoryInfo(TemporaryFolderToDecompress));

            ZipFile.ExtractToDirectory(fileToDecompress.FullName, TemporaryFolderToDecompress);
        }

        private static void CopyContractFilesIntoDestinationFolder()
        {
            var files = Directory.GetFiles(TemporaryFolderToDecompress);

            foreach (var file in files)
            {
                if (file.ToLower().Contains("contract_") && file.ToLower().EndsWith(".xml"))
                {
                    var fileInfoSource = new FileInfo(file);
                    var fileInfoDestination = new FileInfo($@"{DestinationFolder}\{fileInfoSource.Name}");
                    File.Move(file, fileInfoDestination.FullName);
                }
            }
        }

        private static void ParseFilesFromTemporaryFolder()
        {
            var files = Directory.GetFiles(TemporaryFolderToDownload);

            foreach(var file in files)
            {
                DecompressDownloadedFiles(new FileInfo(file));

                CopyContractFilesIntoDestinationFolder();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Загружаем файлы данных с FTP");

            var files = GetFilesInDirectory();

            DownloadFromFtp(files);

            Console.WriteLine("Файлы скачаны!");

            ParseFilesFromTemporaryFolder();

            Console.WriteLine("Разобрали файлы...");

            EmptyTemporaryFolders();

            Console.WriteLine("Работа завершена!");
        }
    }
}
