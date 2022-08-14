using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordsFilePath = "words.txt";
            string textFilePath = "text.txt";
            string outputFilePath = "output.txt";
            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }

        public static async Task CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            using (StreamReader strWords = new StreamReader(wordsFilePath))
            {
                string wordsLine = await strWords.ReadLineAsync();
                string[] words = wordsLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                using (StreamReader strText = new StreamReader(textFilePath))
                {
                    string line = await strText.ReadLineAsync();

                    while (line != null)
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (line.Contains(words[i]))
                            {
                                if (wordsCount.ContainsKey(words[i]) == false)
                                {
                                    wordsCount.Add(words[i], 1);
                                }
                                else if (wordsCount.ContainsKey(words[i]))
                                {
                                    wordsCount[words[i]]++;
                                }
                            }
                        }
                    }
                    using (StreamWriter stw = new StreamWriter(outputFilePath))
                    {
                        foreach (var word in wordsCount)
                        {
                            await stw.WriteLineAsync($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }

}
