using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }
            SortSystem(products);
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }

        static void SortSystem(List<string> products)
        {
            for (int i = 0; i < products.Count-1; i++)
            {
                int min = i;
                for (int j = i+1; j < products.Count; j++)
                {
                    if (products[min].CompareTo(products[j]) > 0)
                    {
                        min = j;
                    }
                }

                string temp = products[i];
                products[i] = products[min];
                products[min] = temp;
            }
        }
    }
}
