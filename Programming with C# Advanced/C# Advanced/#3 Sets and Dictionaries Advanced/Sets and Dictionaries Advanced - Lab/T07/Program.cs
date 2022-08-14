using System;
using System.Collections.Generic;

namespace T07
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                string direction = input[0];
                string number = input[1];
                if (direction == "IN")
                {
                    parkingLot.Add(number);
                }
                else if (direction== "OUT")
                {
                    if (parkingLot.Contains(number))
                    {
                        parkingLot.Remove(number);
                    }
                }
                input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var car in parkingLot)
            {
                Console.WriteLine(car);
            }
        }
    }
}
