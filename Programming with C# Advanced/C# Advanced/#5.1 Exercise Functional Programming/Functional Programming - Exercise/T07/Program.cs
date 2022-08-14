using System;
using System.Collections.Generic;
using System.Linq;

namespace T07
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(Console.ReadLine().Split(' '));
            Predicate<string> filter = name => name.Length <= n;
            Action<List<string>> printer = x => Console.Write(string.Join('\n', x.Where(y => filter(y))));
            printer(names);
        }
    }
}
