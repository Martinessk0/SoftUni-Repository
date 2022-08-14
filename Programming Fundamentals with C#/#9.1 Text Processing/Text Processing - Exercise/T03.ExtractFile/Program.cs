using System;

namespace T03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] url = Console.ReadLine().Split('\\');
            string[] lastPartOfUrl = url[url.Length - 1].Split('.');
            string fileName = lastPartOfUrl[0];
            string fileExtension = lastPartOfUrl[1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
