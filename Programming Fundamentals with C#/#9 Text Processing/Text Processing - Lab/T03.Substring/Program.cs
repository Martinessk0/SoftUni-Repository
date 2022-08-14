using System;

namespace T03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string target = Console.ReadLine();
            int index = target.IndexOf(word);
            while (index>=0)
            {
                target = target.Remove(index, word.Length);
                index = target.IndexOf(word);
            }
            Console.WriteLine(target);
        }
    }
}
