using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader str=new StreamReader(inputFilePath))
            {
                string sb = "";
                string[] exception = {"-", ",", ".", "!", "?"};
                string line = str.ReadLine();
                int index = 0;
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                        for (int i = 0; i < exception.Length; i++)
                        {
                            if (line.Contains(exception[i]))
                            {
                                line=line.Replace(exception[i], "@");
                            }
                        }
                        sb = string.Join(" ", sb.Split().Reverse());
                        result.AppendLine(sb);
                    }
                    line = str.ReadLine();
                    index++;
                }
            }
            return $"{result}";
        }
    }

}
