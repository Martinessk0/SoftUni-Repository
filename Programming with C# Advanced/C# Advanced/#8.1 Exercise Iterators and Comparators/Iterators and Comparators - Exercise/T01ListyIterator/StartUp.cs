using System;
using System.Linq;

namespace T01ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = null;
            ListyIterator<string> listy = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                if (tokens[0] == "Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (tokens[0] == "Print")
                {
                    listy.Print();
                }
                else if (tokens[0] == "PrintAll")
                {
                    listy.PrintAll();
                }
            }
        }
    }
}
