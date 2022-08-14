using System;
using System.Collections.Generic;
using System.Text;

namespace T06SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model,double fuelAmount,double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void Drive(double distance)
        {
            if ((FuelConsumptionPerKilometer * distance) <= FuelAmount)
            {
                FuelAmount -= (FuelConsumptionPerKilometer * distance);
                TravelledDistance +=distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
