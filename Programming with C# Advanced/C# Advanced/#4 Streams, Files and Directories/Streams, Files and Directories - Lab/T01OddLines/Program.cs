using System;
using System.IO;
using System.Threading.Tasks;

namespace OddLines
{
    public class OddLines
    {
        static async Task Main(string[] args)
        {
            string inputFile = @"input.txt";
            string outputFile = @"..\..\..\output.txt";
            ExtractOddLines(inputFile, outputFile);
        }
        public static async Task ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader str = new StreamReader("input.txt"))
            {
                string line = await str.ReadLineAsync();

                using (StreamWriter stw = new StreamWriter("output.txt"))
                {
                    int index = 0;
                    while (line != null)
                    {
                        if (index % 2 == 1)
                        {
                            await stw.WriteAsync(line);
                        }
                        index++;
                        line = await str.ReadLineAsync();
                    }
                }
            }
        }
    }
}
