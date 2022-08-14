using System;
using System.Collections.Generic;

namespace T05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingInfo = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string command = cmd[0];
                string name = cmd[1];
                switch (command)
                {
                    case "register":
                        string plate = cmd[2];
                        if (parkingInfo.ContainsKey(name) && parkingInfo.ContainsValue(plate))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {plate}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{name} registered {plate} successfully");
                            parkingInfo.Add(name, plate);
                        }
                        break;
                    case "unregister":
                        if (!parkingInfo.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        {
                            Console.WriteLine($"{name} unregistered successfully");
                            parkingInfo.Remove(name, out plate);
                        }
                        break;
                }
            }
            foreach (var car in parkingInfo)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
