namespace PolymorphismEx
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm) 
            : base(tankCapacity, fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double FuelConsumptionPerKm
            => this.IsEmpty
            ? base.FuelConsumptionPerKm
            : base.FuelConsumptionPerKm + 1.4;
    }
}
