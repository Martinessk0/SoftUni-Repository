using System;
using Vehicles.Models;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Car car = new Car(carTankCapacity,carFuelQuantity, carFuelConsumption);
            Truck truck = new Truck(truckTankCapacity,truckFuelQuantity, truckFuelConsumption);
            Bus bus = new Bus(busTankCapacity, busFuelQuantity, busFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string type = tokens[1];
                double variable = double.Parse(tokens[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (type == "Car")
                        {
                            if (!car.CanDrive(variable)) Console.WriteLine("Car needs refueling");
                            else
                            {
                                car.Drive(variable);
                                Console.WriteLine($"Car travelled {variable} km");
                            }
                        }
                        else if (type == "Truck")
                        {
                            if (!truck.CanDrive(variable)) Console.WriteLine("Truck needs refueling");
                            else
                            {
                                truck.Drive(variable);
                                Console.WriteLine($"Truck travelled {variable} km");
                            }
                        }
                        else
                        {
                            if (!bus.CanDrive(variable)) Console.WriteLine("Bus needs refueling");
                            else
                            {
                                bus.Drive(variable);
                                Console.WriteLine($"Bus travelled {variable} km");
                            }
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            if (car.CanRefuel(variable))
                            {
                                car.Refuel(variable);
                            }
                            else
                            {
                                Console.WriteLine($"Cannot fit {variable} fuel in the tank");
                            }
                            
                        }
                        else if (type == "Truck")
                        {
                            if (truck.CanRefuel(variable))
                            {
                                truck.Refuel(variable);
                            }
                            else
                            {
                                Console.WriteLine($"Cannot fit {variable} fuel in the tank");
                            }
                        }
                        else
                        {
                            if (bus.CanRefuel(variable))
                            {
                                bus.Refuel(variable);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"Cannot fit {variable} fuel in the tank");
                            }
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        if (bus.CanDrive(variable))
                        {
                            bus.IsEmpty = true;
                            bus.Drive(variable);
                            bus.IsEmpty = false;
                        }
                        else
                        {
                            Console.WriteLine($"Bus needs refueling");
                        }
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
