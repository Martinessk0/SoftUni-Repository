using System;
using System.IO;
using System.Threading.Tasks;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputFilePath = "copyMe.png";
            string outputFilePath = "copyMe-copy.png";
        }
        public static async Task CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fileStreamReader =
                   new FileStream(inputFilePath, FileMode.Open);
            using FileStream fileStreamWriter =
                   new FileStream(outputFilePath, FileMode.Create);

            byte[] bytes = new byte[256];
            while (true)
            {
                int currentBytes = fileStreamReader.Read(bytes, 0, bytes.Length);
                if (currentBytes == 0) break;

                fileStreamWriter.WriteAsync(bytes, 0, bytes.Length);
            }


        }

    }
}
