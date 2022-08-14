using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static async Task RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader str=new StreamReader(inputFilePath))
            {
                string line = await str.ReadLineAsync();
                using (StreamWriter stw=new StreamWriter(outputFilePath))
                {
                    int count = 1;
                    
                    while (line !=null)
                    {
                        Console.WriteLine($"{count}. {line}");
                        //await stw.WriteLineAsync($"{count}. {line}");
                        count++;
                        line = await str.ReadLineAsync();
                    }
                }
            }
        }
    }
}
