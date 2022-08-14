using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity) fuelQuantity = 0;
                else fuelQuantity = value;
            } 
        }
        public virtual double FuelConsumptionPerKm { get;protected set; }
        public bool IsEmpty { get; set; }

        public double TankCapacity { get; }
        public bool CanDrive(double km)
            => FuelQuantity - (km * FuelConsumptionPerKm) >= 0;
        public bool CanRefuel(double amount)
            => FuelQuantity + amount <= TankCapacity;
        public void Drive(double km)
        {
            if (CanDrive(km)) FuelQuantity -= km * FuelConsumptionPerKm;
        }
        public virtual void Refuel(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Fuel must be a positive number");
            if (CanRefuel(amount)) FuelQuantity += amount;

        }
    }
}
