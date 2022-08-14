using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace T07RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tires[] tireArr = new Tires[4]
                {
                    new Tires(tire1Age,tire1Pressure),
                    new Tires(tire2Age,tire2Pressure),
                    new Tires(tire3Age,tire3Pressure),
                    new Tires(tire4Age,tire4Pressure)
                };
                Car car = new Car(model, engine,cargo, tireArr);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            List<Car> outputCars = new List<Car>();
            foreach (var car in cars)
            {
                if (car.Cargo.Type == command)
                {
                    outputCars.Add(car);
                }
            }
            if (command == "fragile")
            {
                List<Car> output=outputCars.Where(Car.GetSpecialCarFragile()).ToList();
                output.ForEach(x => Console.WriteLine(x.Print()));
            }
            else if (command == "flammable")
            {
                List<Car> output = outputCars.Where(Car.GetSpecialCarFlammable()).ToList();
                output.ForEach(x => Console.WriteLine(x.Print()));
            }
        }
    }
}
