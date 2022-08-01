namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A4", 5.5, 60);
        }
        [Test]
        public void CtorShouldCreateAndProperObject()
        {
            string make = car.Make;
            string model = car.Model;
            double fuelConsumption = car.FuelConsumption;
            double fuelCapacity = car.FuelCapacity;
            double fuelAmount = car.FuelAmount;

            Assert.AreEqual("Audi", make);
            Assert.AreEqual("A4", model);
            Assert.AreEqual(5.5, fuelConsumption);
            Assert.AreEqual(60, fuelCapacity);
            Assert.AreEqual(0, fuelAmount);
        }

        [Test]
        public void NullOrEmptyMakeShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(string.Empty, "A4", 5.5, 60);
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void NullOrEmptyModelShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", string.Empty, 5.5, 60);
            }, "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ZeroOrNegativeFuelConsumptionShouldThrowException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A4", fuelConsumption, 60);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ZeroOrNegativeFuelCapacityShouldThrowException(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Audi", "A4", 5.5, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelWithLessThanZeroAmountShouldThrowException(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }


        [TestCase(20)]
        [TestCase(60)]
        public void RefuelWithAmountLessThanFuelCapacity(double fuelToRefuel)
        {
            car.Refuel(fuelToRefuel);
            double currentFuelAmount = car.FuelAmount;
            double expectedFuelAmount = fuelToRefuel;

            Assert.AreEqual(expectedFuelAmount, currentFuelAmount);
        }

        [Test]
        public void RefuelWithMoreThanTheFuelCapacityShouldSetFuelAmountEqualToCapacity()
        {
            car.Refuel(61);
            double currentFuelAmount = car.FuelAmount;
            Assert.AreEqual(60, currentFuelAmount);
        }

        [Test]
        public void DriveWithNotEnoughFuelAmountWhouldThrowException()
        {
            car.Refuel(5.5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(101);
            }, "You don't have enough fuel to drive!");
        }

        [Test]
        public void DriveDistanceShouldDecreaseTheFuelAmount()
        {
            car.Refuel(5.5);
            car.Drive(100);
            double fuelAmount = car.FuelAmount;

            Assert.AreEqual(0, fuelAmount);
        }
    }
}