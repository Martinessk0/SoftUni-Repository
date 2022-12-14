using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            double coinCount = 0;
            double totalCoin = 0;
            while (start != "Start")
            {
                double currCoin = double.Parse(start);
                if (currCoin != 0.1 && currCoin != 0.2 && currCoin != 0.5 && currCoin != 1 && currCoin != 2)
                {
                    Console.WriteLine($"Cannot accept {currCoin}");
                }
                else
                {
                    totalCoin += currCoin;
                }
                start = Console.ReadLine();
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                double price = 0;
                switch (input)
                {
                    case "Nuts":
                        price += 2;
                        break;
                    case "Water":
                        price += 0.7;
                        break;
                    case "Crisps":
                        price += 1.5;
                        break;
                    case "Soda":
                        price += 0.8;
                        break;
                    case "Coke":
                        price += 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                if (price > totalCoin)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                    totalCoin -= price;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalCoin:f2}");
        }
    }
}
