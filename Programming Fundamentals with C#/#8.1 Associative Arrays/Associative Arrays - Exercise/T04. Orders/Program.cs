using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace T04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "buy")
            {
                string nameOfProduct = cmd[0];
                double priceOfProduct = double.Parse(cmd[1]);
                double quantityOfProduct = double.Parse(cmd[2]);
                if (!products.ContainsKey(nameOfProduct))
                {
                    products.Add(nameOfProduct, new double[2]);
                }
                products[nameOfProduct][0] = priceOfProduct;
                products[nameOfProduct][1] += quantityOfProduct;

                cmd = Console.ReadLine().Split();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
            }
        }
    }
}
