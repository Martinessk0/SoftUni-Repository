using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    if (day=="Friday")
                    {
                        price += 8.45;
                    }
                    else if (day=="Saturday")
                    {
                        price += 9.80;
                    }
                    else if (day=="Sunday")
                    {
                        price += 10.46;
                    }

                    if (countOfPeople>=30)
                    {
                        price = (countOfPeople * price) * 0.85;
                        break;
                    }
                    price = (countOfPeople * price);
                    break;
                case "Business":
                    if (day == "Friday")
                    {
                        price += 10.9;
                    }
                    else if (day == "Saturday")
                    {
                        price += 15.6;
                    }
                    else if (day == "Sunday")
                    {
                        price += 16;
                    }

                    if (countOfPeople >= 100)
                    {
                        price = (countOfPeople * price)-(10*price);
                        break;
                    }
                    price = (countOfPeople * price);
                    break;
                case "Regular":
                    if (day == "Friday")
                    {
                        price += 15;
                    }
                    else if (day == "Saturday")
                    {
                        price += 20;
                    }
                    else if (day == "Sunday")
                    {
                        price += 22.50;
                    }

                    if (countOfPeople >= 10 && countOfPeople <=20)
                    {
                        price = (countOfPeople * price) * 0.95;
                        break;
                    }
                    price = (countOfPeople * price);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
