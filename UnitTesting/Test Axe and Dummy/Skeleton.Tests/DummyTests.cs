using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void TakeAttackDummyIsDeadShouldThrowExeprion(int health)
        {
            Dummy dummy = new Dummy(health, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            }, "Dummy id dead.");
        }
        [Test]
        public void DummyHealthShoulDecreaseByAttackPoints()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void DeadDummyShouldReturnExpirience(int health)
        {
            Dummy dummy = new Dummy(health, 10);

            int expirience = dummy.GiveExperience();

            Assert.AreEqual(10, expirience);
        }

        [Test]
        public void LiveDummyShouldNotReturnExpirience()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Target is not dead.");
        }
    }
}