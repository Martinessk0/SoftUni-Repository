using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Audi", "A4", 15, 300);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void TestMakeValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(null, "A4", 15, 300);
            });
        }

        [Test]
        public void TestModelValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Audi", null, 15, 300);
            });
        }

        [Test]
        public void TestFuelConsumptionValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Audi", "A4", -3, 300);
            });
        }

        [Test]
        public void TestFuelCapacityValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Audi", "A4", 15, 0);
            });
        }

        [Test]
        public void TestFuelAmount()
        {
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelingCorrectly()
        {
            this.car.Refuel(15);
            int expectedFuel = 15;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestIfFuelToRefuelIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(-3);
            });
        }

        [Test]
        public void TestIfRefuelMoreThanCapacity()
        {
            this.car.Refuel(350);
            int expectedFuel = 300;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestDrivingCorrectly()
        {
            this.car.Refuel(10);
            this.car.Drive(10);
            double expectedFuel = 8.5;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestDrivingTooMuchDistance()
        {
            this.car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(10);
            });
        }
    }
}