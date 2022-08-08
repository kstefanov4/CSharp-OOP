using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void NullNameValueShouldThrowException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 2);
                }, "Invalid garage name.");
            }

            [Test]
            public void EmptyNameValueShouldThrowException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(string.Empty, 2);
                }, "Invalid garage name.");
            }

            [Test]
            public void GarageNamePropertyShouldWorkCorrectly()
            {
                Garage garage = new Garage("NameTest", 1);

                Assert.AreEqual("NameTest", garage.Name);
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void LessThanOneMechanicsValueShouldThrowException(int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("NameTest", 0);
                }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void GarageMechanicPropertyShouldWorkCorrectly()
            {
                Garage garage = new Garage("NameTest", 1);

                Assert.AreEqual(1, garage.MechanicsAvailable);
            }

            [Test]
            public void AddCarShouldAddToCollection()
            {
                Garage garage = new Garage("TestName", 1);
                garage.AddCar(new Car("CarName", 1));

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void CannotAddCarWithoutAvailableMechanics()
            {
                Garage garage = new Garage("TestName", 1);
                garage.AddCar(new Car("CarName", 1));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("CarName2", 1));
                }, "No mechanic available.");
            }

            [Test]
            public void NullCarToFixShouldThrowException()
            {
                Garage garage = new Garage("TestName", 2);
                garage.AddCar(new Car("CarName", 1));
                garage.AddCar(new Car("CarName2", 2));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("CarName3");
                }, "The car CarName3 doesn't exist.");
            }

            [Test]
            public void FixedCarShouldSetCarNumberOfIssueToZero()
            {
                Garage garage = new Garage("TestName", 2);
                Car car = new Car("CarName", 5);
                garage.AddCar(car);

                garage.FixCar("CarName");
                int carNumberOfIssues = car.NumberOfIssues;

                Assert.AreEqual(0, carNumberOfIssues);
            }

            [Test]
            public void FixCarShouldReturnProperCar()
            {
                Garage garage = new Garage("TestName", 2);
                Car car = new Car("CarName", 5);
                garage.AddCar(car);

                Car fixedCar = garage.FixCar("CarName");

                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo("CarName"));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }

            [Test]
            public void NoAvailableFixedCarsShouldThrowException()
            {
                Garage garage = new Garage("TestName", 2);
                Car car = new Car("CarName", 5);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }

            [Test]
            public void FixedCarsShouldBeRemovedCorrectly()
            {
                Garage garage = new Garage("TestName", 3);
                garage.AddCar(new Car("CarName", 5));
                garage.AddCar(new Car("CarName1", 2));
                garage.AddCar(new Car("CarName3", 10));

                garage.FixCar("CarName");
                garage.FixCar("CarName1");
                garage.FixCar("CarName3");
                int removedFixedCars = garage.RemoveFixedCar();
                Assert.AreEqual(3, removedFixedCars);
            }

            [Test]
            public void ReportShouldReturnProperString()
            {
                Garage garage = new Garage("TestName", 3);
                garage.AddCar(new Car("CarName", 5));
                garage.AddCar(new Car("CarName1", 2));
                garage.AddCar(new Car("CarName3", 10));

                string report = garage.Report();

                Assert.AreEqual("There are 3 which are not fixed: CarName, CarName1, CarName3.", report);
            }
        }

    }
}