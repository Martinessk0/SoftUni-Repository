using System;
using System.Collections.Generic;

namespace Т09
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
             
            while (commands[0] != "Party!")
            {
                switch (commands[1])
                {
                    case "StartsWith":
                        switch (commands[0])
                        {
                            case "Remove":
                                break;
                            case "Double":
                                break;
                        }
                        break;
                    case "EndsWith":
                        switch (commands[0])
                        {
                            case "Remove":
                                break;
                            case "Double":
                                break;
                        }
                        break;
                    case "Length":
                        switch (commands[0])
                        {
                            case "Remove":
                                break;
                            case "Double":
                                break;
                        }
                        break;
                }
                commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
