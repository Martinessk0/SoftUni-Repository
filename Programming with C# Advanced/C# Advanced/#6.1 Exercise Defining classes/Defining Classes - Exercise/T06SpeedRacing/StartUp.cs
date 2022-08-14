using System;
using System.Collections.Generic;

namespace T06SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input=null;
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = cmd[0];
                double fuelAmount = double.Parse(cmd[1]);
                double fuelConsumptionPerKm = double.Parse(cmd[2]);
                Car car = new Car(model,fuelAmount,fuelConsumptionPerKm);
                cars.Add(car);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] date = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = date[1];
                double distance = double.Parse(date[2]);
                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(distance);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
