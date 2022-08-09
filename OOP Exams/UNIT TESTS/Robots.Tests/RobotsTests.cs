namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void TestTheRobotConstructorShouldWorkCorrect()
        {
            Robot robot = new Robot("Robot1", 50);

            Assert.That(robot.Name, Is.EqualTo("Robot1"));
            Assert.That(robot.Battery, Is.EqualTo(50));
            Assert.That(robot.MaximumBattery, Is.EqualTo(50));
        }

    }
}
