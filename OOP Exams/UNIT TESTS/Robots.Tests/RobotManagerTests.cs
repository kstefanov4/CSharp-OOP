using NUnit.Framework;
using System;

namespace Robots.Tests
{
    [TestFixture]
    class RobotManagerTests
    {
        [Test]
        public void CountShouldReturnProperNumber()
        {
            RobotManager robotManager = new RobotManager(1);

            int count = robotManager.Count;

            Assert.AreEqual(0, count);
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void CapacityBelowZeroShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void CapacityPropertyShouldWorksCorrect()
        {
            RobotManager robotManager = new RobotManager(2);

            Assert.AreEqual(2, robotManager.Capacity);
        }

        [Test]
        public void AddingAlreadyExistsRobotShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(3);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Robot2", 60));
            }, "There is already a robot with name Robot2!");
        }

        [Test]
        public void AddingRobotWithoutEnoughtCapacityShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("Robot3", 70));
            }, "Not enough capacity!");
        }

        [Test]
        public void AddPropertyShouldWorksCorrect()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.That(robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveNonExistingRobotShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Robot3");
            }, "Robot with the name Robot3 doesn't exist!");
        }

        [Test]
        public void RemovePropertyShouldWorksCorrect()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));
            robotManager.Remove("Robot2");

            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void WorkWithNonExistingRobotShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robot3","job",10);
            }, "Robot with the name Robot3 doesn't exist!");
        }

        [Test]
        public void WorkWithoutEnoughtBatteryShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robot2", "job", 70);
            }, "Robot2 doesn't have enough battery!");
        }

        [Test]
        public void WorkPropertyShouldDecreaseBattery()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("Robot1", 50);
            Robot robot2 = new Robot("Robot2", 60);

            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work("Robot2","Job",20);

            Assert.That(robot2.Battery, Is.EqualTo(40));
        }

        [Test]
        public void ChargeNonExistingRobotShouldThrowException()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(new Robot("Robot1", 50));
            robotManager.Add(new Robot("Robot2", 60));
            robotManager.Work("Robot2", "Job", 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Robot3");
            }, "Robot with the name Robot3 doesn't exist!");
        }

        [Test]
        public void ChargePropertyShouldIncreaseBatteryToMaximumCapacity()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("Robot1", 50);
            Robot robot2 = new Robot("Robot2", 60);

            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work("Robot2", "Job", 20);
            robotManager.Charge("Robot2");

            Assert.AreEqual(60, robot2.Battery);
        }

    }
}
