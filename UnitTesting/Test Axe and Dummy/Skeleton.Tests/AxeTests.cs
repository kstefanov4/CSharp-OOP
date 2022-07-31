using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void TestAxeConstructor()
        {
            Axe axe = new Axe(50, 60);
            int durabilityPoints = axe.DurabilityPoints;
            int attackPoints = axe.AttackPoints;
            Assert.AreEqual(50, attackPoints);
            Assert.AreEqual(60, durabilityPoints);
        }

        [Test]
        public void DurabilityPointsShhoulDecreaseAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doe not change after attack");

        }
        [TestCase(0)]
        [TestCase(-1)]
        public void AttackWithBrockenAxeShouldThrowExeptionMessage(int durability)
        {
            
            Axe axe = new Axe(10, durability);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}