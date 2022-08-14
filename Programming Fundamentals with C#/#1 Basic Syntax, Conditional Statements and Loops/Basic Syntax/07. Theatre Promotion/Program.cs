using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            double price = 0;

            switch (type)
            {
                case "Weekday":
                    if (age>=0 && age <=18)
                    {
                        price += 12;
                    }
                    else if (age>18 && age <=64)
                    {
                        price += 18;
                    }
                    else if (age>64 && age <=122)
                    {
                        price += 12;
                    }
                    else
                    {
                        price = 0;
                    }
                    break;
                case "Weekend":
                    if (age >= 0 && age <= 18)
                    {
                        price += 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price += 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price += 15;
                    }
                    else
                    {
                        price = 0;
                    }
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18)
                    {
                        price += 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price += 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        price += 10;
                    }
                    else
                    {
                        price = 0;
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            if (price==0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{price}$");
            }
            
        }
    }
}
