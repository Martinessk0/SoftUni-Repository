using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            string firstInputFilePath = "input1.txt";
            string secondInputFilePath = "input2.txt";
            string outputFilePath = "output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
        public static async Task MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<int> list = new List<int>();
            using (StreamReader strText1 = new StreamReader(firstInputFilePath))
            {

                using (StreamReader strText2 = new StreamReader(secondInputFilePath))
                {
                    List<int> numbers = new List<int>();
                    string line1 = await strText1.ReadLineAsync();
                    string line2 = await strText2.ReadLineAsync();
                    while (line1!=null && line2 != null)
                    {
                        if (line1 != null)
                        {
                            numbers.Add(int.Parse(line1));
                        }
                        if (line2 != null)
                        {
                            numbers.Add(int.Parse(line2));
                        }
                        line1 = await strText1.ReadLineAsync();
                        line2 = await strText2.ReadLineAsync();
                    }
                    using (StreamWriter stw=new StreamWriter(outputFilePath))
                    {
                        numbers.Sort();
                        foreach (var number in numbers)
                        {
                            await stw.WriteLineAsync(number.ToString());
                        }
                    }
                }
            }
        }
    }

}

