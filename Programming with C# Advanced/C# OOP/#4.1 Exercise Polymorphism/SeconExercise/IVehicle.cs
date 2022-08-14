namespace PolymorphismEx
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumptionPerKm { get; }

        public double TankCapacity { get; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km);

        public void Drive(double km);

        public void Refuel(double amount);

        public bool CanRefuel(double amount);
    }
}
