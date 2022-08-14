using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }
        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder result = new StringBuilder();

            string[] files = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> filesInfo =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (var filePath in files)
            {
                var info = new FileInfo(filePath);
                string fileName = info.FullName;
                string extenction = info.Extension;
                double size = info.Length / 1024.0;

                if (filesInfo.ContainsKey(extenction) == false)
                {
                    filesInfo.Add(extenction,new Dictionary<string, double>());
                }
                filesInfo[extenction].Add(fileName,size);
            }

            foreach (var item in filesInfo
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => x.Key))
            {
                result.AppendLine(item.Key);
                foreach (var file in item.Value.OrderBy(x =>x.Value))
                {
                    result.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllText(path, textContent);
        }

    }
}
