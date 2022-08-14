using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Generic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //    int n = int.Parse(Console.ReadLine());
            //    List<int> list = new List<int>();
            //    for (int i = 0; i < n; i++)
            //    {
            //        int input =int.Parse(Console.ReadLine());
            //        list.Add(input);
            //    }
            //    Box<int> box = new Box<int>(list);
            //    string[] indexes = Console.ReadLine().Split();
            //    box.Swap(list,int.Parse(indexes[0]),int.Parse(indexes[1]));
            //    Console.WriteLine(box);


            //Task 5 and 6

            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            Box<double> box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CountOfGreaterElemenets(list, elementToCompare));
        }
    }
}
