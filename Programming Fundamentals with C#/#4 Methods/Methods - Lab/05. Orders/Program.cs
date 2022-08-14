using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            PricePerProduct(product,quantity);
        }

        static void PricePerProduct(string product,int quantity)
        {
            int number = quantity;
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price += 1.5;
                    break;
                case "water":
                    price += 1;
                    break;
                case "coke":
                    price += 1.4;
                    break;
                case "snacks":
                    price += 2;
                    break;
            }

            TotalPrice(price, number);
        }

        static void TotalPrice(double price,int quantity)
        {
            double totalPrice = price * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
