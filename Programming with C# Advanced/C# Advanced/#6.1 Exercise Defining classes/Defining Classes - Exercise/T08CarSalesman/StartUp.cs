using System;
using System.Collections.Generic;

namespace T08CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numbersOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < numbersOfEngines; i++)
            {
                string input = Console.ReadLine();
                engines.Add(GetEngine(input));
            }

            int numbersOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numbersOfCars; i++)
            {
                string input = Console.ReadLine();
                cars.Add(GetCar(input,engines));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
                
            }
        }

        private static Car GetCar(string input,List<Engine> engines)
        {
            string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string carModel = data[0];
            string engineModel = data[1];
            Engine engine = engines.Find(x => x.Model == engineModel);
            Car car = new Car(carModel,engine);
            if (data.Length > 2)
            {
                bool isDigit = int.TryParse(data[2], out int weight);
                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = data[2];
                }
            }
            if (data.Length > 3)
            {
                car.Color = data[3];
            }
            
            return car;
        }

        private static Engine GetEngine(string input)
        {
            string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            int power = int.Parse(data[1]);
            Engine engine = new Engine(model,power);
            if (data.Length > 2)
            {
                bool isDigit = int.TryParse(data[2], out int displacement);
                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = data[2];
                }
            }
            if (data.Length >3)
            {
                engine.Efficiency = data[3];
            }
            return engine;
        }
    }
}
