using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = "example.png";
            string bytesFilePath = "bytes.txt";
            string outputPath = "output.bin";
            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }
        public static async Task ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] binaryFile = Encoding.UTF8.GetBytes(binaryFilePath);

            string[] textFile = File.ReadAllLines(bytesFilePath);

            StringBuilder result = new StringBuilder();

            foreach (byte item in binaryFile)
            {
                if (textFile.Contains(item.ToString()))
                {
                    result.Append(item.ToString());
                }
            }

            File.WriteAllText(outputPath, result.ToString());
        }

    }
}
