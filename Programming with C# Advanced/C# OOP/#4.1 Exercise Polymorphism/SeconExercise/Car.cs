namespace PolymorphismEx
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumptionPerKm) 
            : base(tankCapacity, fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override double FuelConsumptionPerKm
            => base.FuelConsumptionPerKm + 0.9;
    }
}
