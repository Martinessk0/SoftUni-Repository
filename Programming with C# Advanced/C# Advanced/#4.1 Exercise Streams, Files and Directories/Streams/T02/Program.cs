using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = "";
            string outputFilePath = "";
            ProcessLines(inputFilePath, outputFilePath);
        }
        public static async Task ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines=await File.ReadAllLinesAsync(inputFilePath);
            for (int i = 1; i <=lines.Length; i++)
            {
                string line = lines[i - 1];
                int countLetters = line.Count(x => char.IsLetter(x));
                int punchMarks = line.Count(x => char.IsPunctuation(x));
                sb.AppendLine($"Line {i + 1}: {line}({countLetters})({punchMarks})");
            }

            await File.WriteAllTextAsync(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
