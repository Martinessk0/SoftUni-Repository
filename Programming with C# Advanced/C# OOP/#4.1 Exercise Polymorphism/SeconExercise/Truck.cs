namespace PolymorphismEx
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm)
            : base(tankCapacity, fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 1.6;

        public override void Refuel(double amount)
        {
            amount *= 0.95;
            base.Refuel(amount);
        }
    }
}
