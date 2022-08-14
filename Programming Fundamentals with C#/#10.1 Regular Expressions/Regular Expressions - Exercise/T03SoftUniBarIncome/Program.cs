using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T03SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern =
                @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<quantity>[\d]+)\|[^|$%.]*?(?<price>[\d]+[.]?[\d]+)?\$";
            string input = Console.ReadLine();
            double totalPrice = 0;

             while (input !="end of shift")
            {
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(input);
                if (isValid)
                {
                    var name = regex.Match(input).Groups["customer"].Value;
                    var product = regex.Match(input).Groups["product"].Value;
                    var quantity = int.Parse(regex.Match(input).Groups["quantity"].Value);
                    var price = double.Parse(regex.Match(input).Groups["price"].Value);
                    double currPrice = price * quantity;

                    Console.WriteLine($"{name}: {product} - {currPrice:F2}");
                    totalPrice += currPrice;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
