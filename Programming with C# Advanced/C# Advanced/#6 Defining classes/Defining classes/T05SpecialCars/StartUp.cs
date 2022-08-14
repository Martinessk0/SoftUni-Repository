using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = null;
            List<Tire[]> tires = new List<Tire[]>();
           
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInput = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int yearTireOne = int.Parse(tiresInput[0]);
                int yearTireTwo = int.Parse(tiresInput[2]);
                int yearTireThree = int.Parse(tiresInput[4]);
                int yearTireFour = int.Parse(tiresInput[6]);

                double pressureTireOne = double.Parse(tiresInput[1]);
                double pressureTireTwo = double.Parse(tiresInput[3]);
                double pressureTireThree = double.Parse(tiresInput[5]);
                double pressureTireFour = double.Parse(tiresInput[7]);

                Tire[] tireArr = new Tire[4]
                {
                    new Tire(yearTireOne,pressureTireOne),
                    new Tire(yearTireTwo,pressureTireTwo),
                    new Tire(yearTireThree,pressureTireThree),
                    new Tire(yearTireFour,pressureTireFour),
                };
                tires.Add(tireArr);
            }

            List<Engine> engines = new List<Engine>();
            while ((input=Console.ReadLine()) != "Engines done")
            {
                string[] engineInput = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineInput[0]);
                double cubicCapacity = double.Parse(engineInput[1]);
                Engine engine = new Engine(horsePower,cubicCapacity);

                engines.Add(engine);
            }
            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] tiresArr = tires[int.Parse(carInfo[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tiresArr);
                cars.Add(car);
            }
            List<Car> specialCars = cars.Where(Car.GetSpecialCars()).ToList();
            specialCars.ForEach(x => x.Drive(20));
            specialCars.ForEach(x => Console.Write(x.Print()));
        }
    }
}
