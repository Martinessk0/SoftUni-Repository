namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; set; }
        double FuelConsumptionPerKm { get;}
        double TankCapacity { get; }
        bool CanDrive(double km);
        void Drive(double km);
        void Refuel(double amount);
    }
}
