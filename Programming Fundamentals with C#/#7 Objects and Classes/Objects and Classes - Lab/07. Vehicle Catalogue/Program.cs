using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        class Cars
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
        class Trucks
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }
        class Catalog
        {
            public Catalog()
            {
                Cars = new List<Cars>();
                Trucks = new List<Trucks>();
            }
            public List<Cars> Cars { get; set; }
            public List<Trucks> Trucks { get; set; }
        }
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split('/');
            Catalog catalog = new Catalog();
            while (cmd[0] != "end")
            {
                string type = cmd[0];
                string brand = cmd[1];
                string model = cmd[2];
                int horesePower = int.Parse(cmd[3]);

                if (type == "Car")
                {
                    Cars car = new Cars()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horesePower
                    };
                    catalog.Cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(cmd[3]);
                    Trucks truck = new Trucks()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    catalog.Trucks.Add(truck);
                }
                cmd = Console.ReadLine().Split('/');
            }
            if (catalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
            }
            foreach (var cars in catalog.Cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{cars.Brand}: {cars.Model} - {cars.HorsePower}hp");
            }
            if (catalog.Trucks.Count!=0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (var trucks in catalog.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{trucks.Brand}: {trucks.Model} - {trucks.Weight}kg");
            }

        }
    }
}
