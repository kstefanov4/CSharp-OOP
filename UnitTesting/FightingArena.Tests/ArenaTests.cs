namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CtorShouldInitializeEmptyListOfWarriors()
        {
            Arena arena = new Arena();

            int warriorsCount = arena.Warriors.Count;

            Assert.AreEqual(0, warriorsCount);
        }

        [Test]
        public void CountShouldReturnProperNumber()
        {
            Arena arena = new Arena();

            int warriorsCount = arena.Count;

            Assert.AreEqual(0, warriorsCount);
        }

        [Test]
        public void AddingWarriorWithTheSameNameShouldThrowException()
        {
            Arena arena = new Arena();

            arena.Enroll(new Warrior("user1", 40, 40));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("user1", 40, 40));
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TryingFightWithMissingWarrionShouldThrowException()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("warrior1", 50, 35);
            Warrior defender = new Warrior("warrior2", 30, 40);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("warrior1", "TestName");
            }, $"There is no fighter with name TestName enrolled for the fights!");
        }

        [Test]
        public void ArenaFightShouldDecreaseEnemy()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("warrior1", 35, 35);
            Warrior enemy = new Warrior("warrior2", 30, 40);
            arena.Enroll(warrior);
            arena.Enroll(enemy);

            arena.Fight("warrior1", "warrior2");

            Assert.AreEqual(5, enemy.HP);
        }
    }
}
