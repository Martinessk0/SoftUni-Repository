using System;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    class Program 
    {
        class Cars
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }
        class Trucks
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }
        class Catalog
        {
            public Catalog()
            {
                CarsCatalog = new List<Cars>();
                TrucksCatalog = new List<Trucks>();
            }
            public List<Cars> CarsCatalog = new List<Cars>();
            public List<Trucks> TrucksCatalog = new List<Trucks>();
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int countCar = 0;
            int countTruck = 0;
            double averageHpCars = 0;
            double averageHpTrucks = 0;
            Catalog catalog = new Catalog();
            while (input[0] != "End")
            {
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);

                switch (type)
                {
                    case "car":
                        Cars car = new Cars()
                        {
                            Type = type,
                            Model = model,
                            Color = color,
                            HorsePower = horsePower
                        };
                        averageHpCars += horsePower;
                        countCar++;
                        catalog.CarsCatalog.Add(car);
                        break;
                    case "truck":
                        Trucks truck = new Trucks()
                        {
                            Type = type,
                            Model = model,
                            Color = color,
                            HorsePower = horsePower
                        };
                        averageHpTrucks += horsePower;
                        countTruck++;
                        catalog.TrucksCatalog.Add(truck);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            string command = Console.ReadLine();
            while (command != "Close the Catalogue")
            {
                foreach (var car in catalog.CarsCatalog)
                {
                    if (car.Model.Contains(command))
                    {
                        Console.WriteLine($"Type: Car");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }
                foreach (var car in catalog.TrucksCatalog)
                {
                    if (car.Model.Contains(command))
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }
                command = Console.ReadLine();
            }

            if (catalog.CarsCatalog.Count >= 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(averageHpCars / countCar):f2}.");
            }
            if (catalog.TrucksCatalog.Count >= 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(averageHpTrucks / countTruck):f2}.");
            }
        }
    }
}
